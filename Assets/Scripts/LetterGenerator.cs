using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LetterGenerator : MonoBehaviour
{
    public List<GameObject> letters;
    public List<LetterSlot> letterSlots;

    public GameObject spawnEffect;
    public AudioManager audioManager;

    private Word word;
    private List<GameObject> instantiatedLetters = new List<GameObject>();
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
        

        if (SlotsEmpty())
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
                                instantiatedLetter.GetComponent<SpriteRenderer>().enabled = false;
                                instantiatedLetters.Add(instantiatedLetter);
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

        StartCoroutine(Delay(0.5f));
        
    }

    private int GetRandomSlotNumber()
    {
        return Random.Range(0, letterSlots.Count);
    }

    private bool SlotsEmpty()
    {
        return letterSlots.All(slot => slot.AssignedLetter == null);
    }

    IEnumerator Delay(float time)
    {
        foreach (var letter in instantiatedLetters)
        {            
            letter.GetComponent<SpriteRenderer>().enabled = true;
            Instantiate(spawnEffect, letter.transform.position, Quaternion.identity).transform.SetAsFirstSibling();
            audioManager.PlaySound(Sound.SPAWN);
            yield return new WaitForSeconds(time);
        }       
        
    }
}
