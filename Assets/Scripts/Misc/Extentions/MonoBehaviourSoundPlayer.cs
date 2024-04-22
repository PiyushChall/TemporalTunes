using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Misc.Extentions
{
    public static class MonoBehaviourSoundPlayer
    {
        public static void PlayAudioOneShot(this MonoBehaviour behaviour, AudioClip clip)
        {
            AudioSource source;
            if(!behaviour.TryGetComponent(out source))
                source = behaviour.gameObject.AddComponent<AudioSource>();
            source.PlayOneShot(clip);

        }
        public static void PlayAudio(this MonoBehaviour behaviour, AudioClip clip, bool loop = false, Condition condition = null, float pitch = 1)
        {
            AudioSource source = behaviour.gameObject.AddComponent<AudioSource>();
            source.clip = clip;
            source.loop = loop;
            source.pitch = pitch;
            //source.outputAudioMixerGroup = Resources.Load<AudioMixer>("MainAudioMixer").FindMatchingGroups("VFX").First();
            source.Play();
            behaviour.StartCoroutine(JunkSourceCleaner(source));
            if (condition != null && loop)
                behaviour.StartCoroutine(LoopUntilCourotine(source, condition));
        }
        private static IEnumerator JunkSourceCleaner(AudioSource source)
        {
            yield return new WaitUntil(() => !source.isPlaying);
            UnityEngine.Object.Destroy(source);
        }

        private static IEnumerator LoopUntilCourotine(AudioSource source, Condition cond)
        {
            yield return new WaitUntil(() =>
            cond());
            source.Stop();
        }
    }
}
