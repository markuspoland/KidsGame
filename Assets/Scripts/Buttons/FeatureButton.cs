using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureButton : MonoBehaviour
{
    public Sprite enabledSprite;
    public Sprite disabledSprite;

    public Feature feature;

    public bool FeatureEnabled { get; set; }

    void Start()
    {
        CheckStatus();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (FeatureEnabled)
            {
                Disable();
            }
            else if (!FeatureEnabled)
            {
                Enable();
            }
        }
    }



    public void Enable()
    {
        FeatureEnabled = true;
        EnableFeature();
    }

    public void Disable()
    {
        FeatureEnabled = false;
        DisableFeature();
    }

    private void DisableFeature()
    {
        GetComponent<SpriteRenderer>().sprite = disabledSprite;

        switch (feature)
        {
            case Feature.MUSIC:
                FindObjectOfType<AudioManager>().MusicEnabled = false;
                FindObjectOfType<Music>().GetComponent<AudioSource>().mute = true;
                break;
            case Feature.SOUNDS:
                FindObjectOfType<AudioManager>().SoundEnabled = false;
                break;
        }
    }

    private void EnableFeature()
    {
        GetComponent<SpriteRenderer>().sprite = enabledSprite;

        switch (feature)
        {
            case Feature.MUSIC:
                FindObjectOfType<AudioManager>().MusicEnabled = true;
                FindObjectOfType<Music>().GetComponent<AudioSource>().mute = false;
                break;
            case Feature.SOUNDS:
                FindObjectOfType<AudioManager>().SoundEnabled = true;
                break;
        }
    }

    private void CheckStatus()
    {
        var audioManager = FindObjectOfType<AudioManager>();

        if (audioManager != null)
        {
            switch (feature)
            {
                case Feature.SOUNDS:
                    if (!audioManager.SoundEnabled)
                        GetComponent<SpriteRenderer>().sprite = disabledSprite;
                    else if (audioManager.SoundEnabled)
                        GetComponent<SpriteRenderer>().sprite = enabledSprite;
                    break;
                case Feature.MUSIC:
                    if (!audioManager.MusicEnabled)
                        GetComponent<SpriteRenderer>().sprite = disabledSprite;
                    else if (audioManager.MusicEnabled)
                        GetComponent<SpriteRenderer>().sprite = enabledSprite;
                    break;
            }
        }
    }
}
