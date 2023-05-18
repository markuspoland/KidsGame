using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
                    var randomSlotNumber = GetRandomSlotNumber();
                    var randomSlot = letterSlots[randomSlotNumber];

                    if (randomSlot.AssignedLetter != null)
                    {
                        randomSlotNumber = GetRandomSlotNumber();
                        randomSlot = letterSlots[randomSlotNumber];
                    }

                    if (randomSlot.AssignedLetter == null)
                    {
                        randomSlot.AssignedLetter = letter;
                        var instantiatedLetter = Instantiate(letter, randomSlot.transform.position, Quaternion.identity);
                        instantiatedLetter.name = slotLetter.name;
                    }
                    else continue;
                    break;
                }
            }
        }
    }

    private int GetRandomSlotNumber()
    {
        return Random.Range(0, letterSlots.Count);
    }
}
