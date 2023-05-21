using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Word : MonoBehaviour
{
    public List<GameObject> SlotLetters;

    private int CompletionCount;
    public int LettersCompleted;

    private void Start()
    {
        CompletionCount = SlotLetters.Count;
        LettersCompleted = 0;
    }

    public void CheckProgress()
    {
        if (LettersCompleted >= CompletionCount)
        {
            Debug.Log("WORD COMPLETED !!!");
        }
    }
}
