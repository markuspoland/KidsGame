using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    //[HideInInspector]
    public LetterSlot AssignedSlot { get; set; }
    void Start()
    {
        AssignedSlot = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unassign()
    {
        if (AssignedSlot != null)
        {
            AssignedSlot.AssignedLetter = null;
            AssignedSlot = null;
        }
    }
}
