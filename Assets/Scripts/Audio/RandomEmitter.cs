using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

/** Audio emitter that plays random one-shots at
    randomized time intervals **/

[RequireComponent(typeof(AudioSource))] 
public class RandomEmitter : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioClips; // The audio clips to randomly pick from

    [SerializeField]
    float minTimeBetweenClips = 0f; // Minimum time between clips

    [SerializeField]
    float maxTimeBetweenClips = 5f; // Maximum time between clips

    AudioSource emitter; // Audio source we use to play the clips

    float timeToNextClip = 0f; // Time remaining until the next clip

    void Start() // Start is called before the first frame update
    {
        emitter = GetComponent<AudioSource>();
        SetRandomTimeToNextClip();
    }

    void Update() // Update is called once per frame
    {
        if (timeToNextClip <= 0f)
        {
            PlayRandomClip();
            SetRandomTimeToNextClip();
        }

        timeToNextClip -= Time.deltaTime;
    }
    
    void PlayRandomClip() // Play a random audio clip
    {
        int i = Random.Range(0, audioClips.Length - 1);
        AudioClip clip = audioClips[i];
        emitter.PlayOneShot(clip, 1f);
        Debug.LogFormat("RandomEmitter: Playing {0}", clip.name);
    }

    void SetRandomTimeToNextClip() // Set the time-to-next-clip to a random time
                                   // between the min and max times
    {
        timeToNextClip = Random.Range(minTimeBetweenClips,
                                      maxTimeBetweenClips);
        Debug.LogFormat("RandomEmitter: Waiting {0}s...", timeToNextClip);
    }
}
