using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Word : MonoBehaviour
{
    public List<GameObject> SlotLetters;
    public GameObject completeEffect;
    public AudioManager AudioManager { get; private set; }
    public bool Completed { get; private set; }

    private LetterGenerator letterGenerator;
    private int CompletionCount;

    [HideInInspector]
    public int LettersCompleted;

    private void Start()
    {
        Completed = false;
        CompletionCount = SlotLetters.Count;
        LettersCompleted = 0;
        AudioManager = FindObjectOfType<AudioManager>();
        letterGenerator = FindObjectOfType<LetterGenerator>();
    }

    public void CheckProgress()
    {
        if (LettersCompleted >= CompletionCount)
        {
            Completed = true;
            StartCoroutine(Complete());
        }
    }

    public void InstantiateCompleteEffect(Vector3 position)
    {
        Instantiate(completeEffect, position, Quaternion.identity);
    }

    IEnumerator Complete()
    {       
        for (int i = 0; i < SlotLetters.Count; i++)
        {
            var slotLetter = SlotLetters[i];
            var letter = letterGenerator.InstantiatedLetters.Find(l => l.name == slotLetter.name && l.GetComponent<SpriteRenderer>().enabled == true);
            InstantiateCompleteEffect(slotLetter.transform.position);
            if (letter != null)
            {
                letter.GetComponent<SpriteRenderer>().enabled = false;
            }

            AudioManager.PlaySound(Sound.LetterComplete);
            yield return new WaitForSeconds(0.5f);
        }

        var dragSlots = GetComponentsInChildren<DragSlot>();

        foreach (var slot in dragSlots)
        {
            slot.IsEmpty = true;
        }

        letterGenerator.ResetGenerator();
        AudioManager.PlaySound(Sound.WordComplete);
        LettersCompleted = 0;
        Completed = false;
        gameObject.SetActive(false);

        var spawner = FindObjectOfType<WordSpawner>();
        spawner.Spawn();
        spawner.RemoveWord(gameObject);

        CountCompletedWords();

    }

    private void CountCompletedWords()
    {
        var wordCounter = FindObjectOfType<WordCounter>();

        if (wordCounter != null)
        {
            wordCounter.CompletedWordsOverall++;

            if (wordCounter.CompletedWordsPartial < 25)
            {
                wordCounter.CompletedWordsPartial++;

                if (wordCounter.CompletedWordsPartial == 25)
                {
                    wordCounter.DisplayAcknowledgement();
                    wordCounter.CompletedWordsPartial = 0;
                }
            }  
        }
    }
}
