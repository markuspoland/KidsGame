using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGenerator : MonoBehaviour
{
    public List<GameObject> letters;

    private Word word;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Generate();
        }
    }

    private void Generate()
    {
        word = FindObjectOfType<Word>();

        foreach (var letter in letters)
        {
            foreach (var slotLetter in word.Letters)
            {
                if (letter.name == slotLetter.name)
                {
                    Debug.Log(letter.name);
                }
            }
        }
    }
}
