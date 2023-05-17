using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool dragging;

    private float startPosX;
    private float startPosY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dragging)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {         
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;

            dragging = true;
        }
    }

    private void OnMouseUp()
    {
        dragging = false;
    }
}
