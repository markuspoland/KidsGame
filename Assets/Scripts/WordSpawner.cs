using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public List<GameObject> words;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        if (words.Any(w => w.activeInHierarchy) || words.Count <= 0) return;

        words[GetRandomWordNumber()].SetActive(true);
    }

    private int GetRandomWordNumber()
    {
        return Random.Range(0, words.Count);
    }

    public void RemoveWord(GameObject word)
    {
        words.Remove(word);
    }
}
