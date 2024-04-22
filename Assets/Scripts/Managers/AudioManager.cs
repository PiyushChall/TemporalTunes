using Assets.Scripts.Misc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using UnityEngine;

class AudioManager : Singleton<AudioManager>
{
    private static Dictionary<string, AudioClip> audioClips = new();
    private static AudioSource background;
    

    public static void Load(string name)
    {
        if (audioClips.ContainsKey(name))
            return;

        AudioClip loadedClip = Resources.Load<AudioClip>(Constants.AudioRoot + name);
        if (loadedClip != null)
            audioClips[name] = loadedClip;
        else
            Debug.LogError("Trying load non existing clip by path: Assets/Resources/"+ Constants.AudioRoot + name);
    }

    public static void Unload(string name)
    {
        Resources.UnloadAsset(audioClips[name]);
    }

    public static AudioClip Get(string name)
    {
        if (!audioClips.ContainsKey(name))
            Load(name);
        return audioClips[name];
    }

    static public void SetBackgroundTrack(AudioClip clip)
    {
        if(background == null)
        {
            GameObject obj = GameObject.Instantiate(new GameObject());
            background = obj.AddComponent<AudioSource>();
            background.gameObject.AddComponent<AudioManager>();
            background.loop = true;
            UnityEngine.Object.DontDestroyOnLoad(obj);
        }

        if (clip != null)
        {
            //background.clip = clip;
            ////TODO: Add smooth transition
            //background.Play();
            Instance.StartCoroutine(SmoothBackgroundCourotine(clip));
        }
        else
            background.Pause();
    }

    private static IEnumerator SmoothBackgroundCourotine(AudioClip clip)
    {
        float volBase = background.volume;
        float step = volBase / (Constants.BG_SoundTransitionInterval/2*10);
        if (background.isPlaying)
            while (background.volume > 0)
            {
                background.volume -= step;
                yield return new WaitForSeconds(.1f);
            }
        background.clip = clip;
        background.Play();
        while (background.volume < volBase)
        {
            background.volume += step;
            yield return new WaitForSeconds(.1f);
        }
        background.volume = volBase;
        yield return null;
    }

    static public void SetBackgroundTrack(string clipName)
    {
        SetBackgroundTrack(Get(clipName));
    }


}