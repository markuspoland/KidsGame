using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterGenerator : MonoBehaviour
{
    public List<GameObject> letters;
    public List<LetterSlot> letterSlots;

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
                    foreach (var slot in letterSlots)
                    {
                        if (slot.AssignedLetter == null && slot.AssignedLetter != letter)
                        {
                            slot.AssignedLetter = letter;
                            var instantiatedLetter = Instantiate(letter, slot.transform.position, Quaternion.identity);
                            instantiatedLetter.name = slotLetter.name;
                            break;
                        }
                    }
                }
            }
        }
    }
}
