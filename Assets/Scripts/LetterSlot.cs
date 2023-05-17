using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSlot : MonoBehaviour
{
    [HideInInspector]
    public GameObject AssignedLetter;
    void Start()
    {
        AssignedLetter = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
