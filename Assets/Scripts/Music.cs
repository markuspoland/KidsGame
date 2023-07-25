using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music Instance;

    private void Awake()
    {
        if (Instance != null)        
            Destroy(gameObject);        
        else 
            Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
