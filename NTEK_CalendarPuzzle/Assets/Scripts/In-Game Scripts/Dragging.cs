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
    [SerializeField]private AudioSource initialClickSound;
    [SerializeField]private AudioSource FinalClickSound;
    [SerializeField]private AudioSource FailClickSound;

    private void OnMouseDown()
    {
        initialClickSound.Play();
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
        if (!isWalled)
        {
            FinalClickSound.Play();
        }

        // Return to initial position if there was a collision with another draggable object
        if (isWalled)
        {
            FailClickSound.Play();
            transform.position = initialPos;
            isWalled = false; // Reset the flag after returning to the initial position
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Selectable")
        {
            isWalled = true;
        }
        // Debug.Log("isWalled " + isWalled);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Selectable")
        {
            isWalled = false;
        }
        // Debug.Log("isWalled " + isWalled);
    }
}