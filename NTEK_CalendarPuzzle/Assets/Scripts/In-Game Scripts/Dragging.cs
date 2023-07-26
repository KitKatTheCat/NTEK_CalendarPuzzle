using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    public delegate void DragEndedDelegate(Dragging DraggingObject);

    public DragEndedDelegate dragEndedCallback;

    [SerializeField] private GameObject grid;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    private Vector2 initialPos;
    private bool isDragged = false;
    private bool isWalled = false;

    private void OnMouseDown()
    {
        initialPos = transform.position;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
        grid.SetActive(true);
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
            grid.SetActive(true);
        }
        
    }

    private void OnMouseUp()
    {
        isDragged = false;
        grid.SetActive(false);
        if (isWalled)
        {
            transform.position = initialPos;
        }
        dragEndedCallback(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            isWalled = true;
        }
        Debug.Log("isWalled " + isWalled);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            isWalled = false;
        }
        Debug.Log("isWalled " + isWalled);
    }
}
