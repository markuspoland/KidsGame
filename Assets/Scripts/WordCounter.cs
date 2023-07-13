using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCounter : MonoBehaviour
{
    public int CompletedWordsOverall { get; set; }
    public int CompletedWordsPartial { get; set; }
    void Start()
    {
        CompletedWordsOverall = 0;
        CompletedWordsPartial = 0;
    }

    public void DisplayAcknowledgement()
    {
        //TODO: Display progress message
        Debug.Log("Overall words completed: " + CompletedWordsOverall);
        Debug.Log("Good job! Another " + CompletedWordsPartial + " completed!");
    }

}
