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
    private Word word;
    private DragSlot dragSlot;
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
        if (dragging)
        {
            dragging = false;

            if (isOnSlot && dragSlot.IsEmpty)
            {
                FitToSlot();

            }
            else //if (!isOnSlot)
            {
                transform.position = startingPosition;
            }
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision);
    }

    private void CheckCollision(Collider2D collision)
    {
        DragSlot slot;
        if (collision.TryGetComponent(out slot))
        {

            if (slot.slotFor == gameObject.name)
            {
                slotPosition = collision.transform.position;
                word = collision.GetComponentInParent<Word>();
                dragSlot = collision.GetComponent<DragSlot>();
                isOnSlot = true;
            }
            else if (slot.slotFor != gameObject.name)
            {
                isOnSlot = false;
            }
        }
    }
    private void FitToSlot()
    {
        transform.position = slotPosition;
        dragging = false;
        canDrag = false;
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 0;
        if (word != null)
        {
            word.LettersCompleted++;
        }
        dragSlot.IsEmpty = false;
        word.CheckProgress();
        GetComponent<Letter>().Unassign();
    }


}
