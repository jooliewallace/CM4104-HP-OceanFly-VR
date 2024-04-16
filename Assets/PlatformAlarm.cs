using System;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip soundClip; 
    public bool playSound = true; 
    public float minDelay = 120.0f; 
    public float maxDelay = 240.0f; 
    public float volume = 1.0f; 
    private bool hasPlayed = false;

    void Start()
    {
        if (playSound)
        {
            // Generate a random delay between the min and max durations
            float randomDelay = UnityEngine.Random.Range(minDelay, maxDelay); 
            Invoke("PlaySound", randomDelay);
        }
    }

    void PlaySound()
    {
        if (!hasPlayed && playSound)
        {
            GameObject soundObject = new GameObject("TempSoundObject");
            AudioSource audioSource = soundObject.AddComponent<AudioSource>();

            audioSource.volume = volume;

            audioSource.PlayOneShot(soundClip);

            // Destroy the temporary GameObject after the sound has finished playing
            Destroy(soundObject, soundClip.length);

            hasPlayed = true;
        }
    }
}
