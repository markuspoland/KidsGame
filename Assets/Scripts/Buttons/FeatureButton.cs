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
        FeatureEnabled = true;
        GetComponent<SpriteRenderer>().sprite = enabledSprite; 
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (FeatureEnabled)
            {
                Disable();
            } else if (!FeatureEnabled)
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
                //TODO: Turn off music
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
                //TODO: Turn on music
                break;
            case Feature.SOUNDS:
                FindObjectOfType<AudioManager>().SoundEnabled = true;
                break;
        }
    }
}
