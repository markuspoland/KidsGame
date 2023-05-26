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
        foreach(var slotLetter in SlotLetters)
        {
            InstantiateCompleteEffect(slotLetter.transform.position);
            foreach (var letter in letterGenerator.InstantiatedLetters)
            {
                if (letter.name == slotLetter.name)
                {
                    letter.GetComponent<SpriteRenderer>().enabled = false;
                    break;
                }
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
        FindObjectOfType<WordSpawner>().Spawn();
    }
}
