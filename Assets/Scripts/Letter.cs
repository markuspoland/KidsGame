using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Letter : MonoBehaviour
{
    //[HideInInspector]
    public LetterSlot AssignedSlot { get; set; }

    void Start()
    {
        AssignedSlot = null;
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
