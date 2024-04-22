using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Misc.Tools;
using Assets.Scripts.Misc;
using UnityEditor;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.Events;
using Assets.Scripts.Misc.Extentions;

public class OrganBehaviour : Singleton<OrganBehaviour>
{

    [SerializeField]
    List<Skill> skills = new List<Skill>();

    [Header("Reset Interval")]
    [SerializeField]
    float skillResetInterval;

    [SerializeField]
    AudioSource organAuidioSource = null;

    public List<Skill> Skills { get => skills; }
    public bool IsSupporting { get => isSupporting;}
    public char NextNote { get => nextNote; }

    private string lastCombination;
    private float lastNoteTime = 0;
    private bool isCombinationInput = false;
    private Skill supportedSkill;
    private bool isSupporting = false;
    private char nextNote;

    void Start()
    {
        if (organAuidioSource == null)
            organAuidioSource = gameObject.AddComponent<AudioSource>();
    }

    public void AddSkill(Skill skill)
    {
        skills.Add(skill);
    }
    
    void Update()
    {
        if(!isSupporting)
            RetriveNotes();
        else
            supportedSkill.loop.Invoke();
    }

    private void RetriveNotes()
    {
        KeyCode keyPressed = InputTools.GetAnyKeyDown(Constants.notesKeys.Keys);

        if (keyPressed != KeyCode.None)
        {
            PlayTone((char)Constants.notesKeys[keyPressed]);
            Note note = Constants.notesKeys[keyPressed];
            isCombinationInput = true;
            lastNoteTime = Time.time;
            lastCombination += (char)note;
            Debug.Log(lastCombination);
            if(lastCombination.Length >= 2)
                CheckCombination();
        }
        else if (isCombinationInput)
        {
            if (Time.time - lastNoteTime > skillResetInterval)
            {
                lastCombination = "";
                isCombinationInput = false;
            }
        }

    }

    private void PlayTone(char note)
    {
        AudioClip tone = AudioManager.Get("organ");
        organAuidioSource.pitch = Constants.notesPitch[note];
        organAuidioSource.PlayOneShot(tone);
    }

    private void CheckCombination()
    {
        Skill skill = skills.Find(s=>s.triggerNotes.ToLower() == lastCombination.ToLower());
        if (skill != null)
        {
            ExecuteSkill(skill);
        }
    }

    private void ExecuteSkill(Skill skill)
    {
        if (!skill.isLoop)
            skill.start.Invoke();
        else
        {
            isSupporting = true;
            supportedSkill = skill;
            StartCoroutine(supportingCourotine(skill.loopNotes));
        }
        lastCombination = "";
    }

    private IEnumerator supportingCourotine(string loop)
    {
        loop = loop.ToLower();
        int step = 0, steps = loop.Length;
        while (true)
        {
            char expectedNote = loop[step];
            nextNote = expectedNote;
            KeyCode keyPressed = InputTools.GetAnyKeyDown(Constants.notesKeys.Keys);
            if (keyPressed == KeyCode.None)
                if (Time.time - lastNoteTime > skillResetInterval)
                    break;
                else
                {
                    yield return null;
                    continue;
                }
            else
            {
                PlayTone((char)Constants.notesKeys[keyPressed]);
                lastNoteTime = Time.time;
                step++;
                if ((char)Constants.notesKeys[keyPressed] != expectedNote)
                    break;
                if (step > steps-1)
                    step = 0;
            }
            yield return null;
        }
        isSupporting = false;
        yield return null;
        supportedSkill.end.Invoke();
        supportedSkill = null;
    }
}