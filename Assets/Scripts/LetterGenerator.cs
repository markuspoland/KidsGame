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

        foreach (var slotLetter in word.SlotLetters)
        {
            foreach (var letter in letters)
            {
                if (letter.name == slotLetter.name)
                {
                    while (true)
                    {
                        var randomSlot = letterSlots[GetRandomSlotNumber()];

                        if (randomSlot.AssignedLetter == null)
                        {
                            randomSlot.AssignedLetter = letter;                            
                            var instantiatedLetter = Instantiate(letter, randomSlot.transform.position, Quaternion.identity);
                            instantiatedLetter.name = slotLetter.name;
                            instantiatedLetter.GetComponent<Letter>().AssignedSlot = randomSlot;
                            break;
                        }
                    }
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
