using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool canDrag;
    private bool dragging;
    private bool isOnSlot;

    private float startPosX;
    private float startPosY;

    private Vector3 startingPosition;
    private Vector3 slotPosition;
    void Start()
    {
        startingPosition = transform.position;
        canDrag = true;
        isOnSlot = false;
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

            if (canDrag) dragging = true;
        }
    }

    private void OnMouseUp()
    {
        dragging = false;

        if (isOnSlot)
        {
            transform.position = slotPosition;
            dragging = false;
            canDrag = false;
        } else if (!isOnSlot)
        {
            transform.position = startingPosition;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        DragSlot slot;
        if (collision.TryGetComponent<DragSlot>(out slot))
        {
            
            if (slot.slotFor == gameObject.name)
            {
                slotPosition = collision.transform.position;
                isOnSlot = true;
            }
        }
    }


}
