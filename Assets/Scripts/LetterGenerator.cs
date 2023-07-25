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
    public List<GameObject> InstantiatedLetters { get; set; } = new List<GameObject>();

    private bool spawned;
    private bool canPlaySound;


    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        spawned = false;
        canPlaySound = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && canPlaySound) 
        {
            Generate();
            //canPlaySound = true;
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
                                InstantiatedLetters.Add(instantiatedLetter);
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

        if (!spawned) StartCoroutine(Delay(0.5f));
    }

    public void ResetGenerator()
    {
        spawned = false;

        foreach (var letter in InstantiatedLetters)
        {
            Destroy(letter);
        }

        InstantiatedLetters = new List<GameObject>();
        word = null;

        foreach(var slot in letterSlots)
        {
            slot.AssignedLetter = null;
        }
    }

    private int GetRandomSlotNumber()
    {
        return Random.Range(0, letterSlots.Count);
    }

    private bool SlotsEmpty() => letterSlots.All(slot => slot.AssignedLetter == null);    

    IEnumerator Delay(float time)
    {
        canPlaySound = false;

        foreach (var letter in InstantiatedLetters)
        {
            letter.GetComponent<SpriteRenderer>().enabled = true;
            Instantiate(spawnEffect, letter.transform.position, Quaternion.identity).transform.SetAsFirstSibling();
            audioManager.PlaySound(Sound.Spawn);            
            yield return new WaitForSeconds(time);
        }

        canPlaySound = true;
        spawned = true;
    }
}
