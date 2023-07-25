using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(gameObject);
            created = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
