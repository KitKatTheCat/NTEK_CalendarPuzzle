using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
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
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
        
    }

    private void OnMouseUp()
    {
        isDragged = false;
        if (isWalled)
        {
            transform.position = initialPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Wall")
        {
            isWalled = true;
        }
        // Debug.Log("isWalled " + isWalled);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            isWalled = false;
        }
        // Debug.Log("isWalled " + isWalled);
    }
}