using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSlot : MonoBehaviour
{
    public string slotFor;

    public bool IsEmpty { get; set; }
    void Start()
    {
        IsEmpty = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
