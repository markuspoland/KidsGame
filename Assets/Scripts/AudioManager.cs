using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Letter Sounds")]
    public AudioClip letterSpawn;
    public AudioClip letterComplete;
    public AudioClip wordComplete;
    public AudioClip wrongSlot;

    public bool SoundEnabled { get; set; } = true;
    public bool MusicEnabled { get; set; } = true;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(Sound sound)
    {
        if (SoundEnabled)
        {
            switch (sound)
            {
                case Sound.Spawn:
                    audioSource.PlayOneShot(letterSpawn);
                    break;
                case Sound.LetterComplete:
                    audioSource.PlayOneShot(letterComplete);
                    break;
                case Sound.WordComplete:
                    audioSource.PlayOneShot(wordComplete);
                    break;
                case Sound.WrongSlot:
                    audioSource.PlayOneShot(wrongSlot); 
                    break;
            }
        }
        
    }

    public bool IsSoundMuted()
    {
        return SoundEnabled;
    }
}
