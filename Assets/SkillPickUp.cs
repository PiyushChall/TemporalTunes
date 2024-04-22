using Assets.Scripts.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPickUp : MonoBehaviour
{
    static readonly Dictionary<string, Skill> skills = new();

    [SerializeField]
    private string skillName;

    private OrganBehaviour organ;

    // Start is called before the first frame update
    void Start()
    {
        organ = OrganBehaviour.Instance;

        skills.Add("AgeUp", Skills.Age);
        skills.Add("AgeDown", Skills.Unage);
        skills.Add("Pause", Skills.Pause);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<OrganBehaviour>().AddSkill(skills[skillName]);
        }
    }
}

