using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Letter Sounds")]
    public AudioClip letterSpawn;

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
                case Sound.SPAWN:
                    audioSource.PlayOneShot(letterSpawn);
                    break;
            }
        }
        
    }
}
