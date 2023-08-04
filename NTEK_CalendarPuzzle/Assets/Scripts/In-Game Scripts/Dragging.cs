using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragging : MonoBehaviour
{
    public delegate void DragEndedDelegate(Dragging draggingObject);

    public DragEndedDelegate dragEndedCallback;

    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;
    public Vector2 InitialPos { get; private set; }
    private bool isDragged = false;
    [SerializeField]private int isWalledCounter;
    [SerializeField] private AudioSource initialClickSound;
    [SerializeField] private AudioSource finalClickSound;
    [SerializeField] private AudioSource failClickSound;
    private WinCondition winCondition;

    public bool IsDragged => isDragged; // Add a property to access the dragging flag

    private void Start()
    {
        winCondition = FindObjectOfType<WinCondition>();
        InitialPos = transform.position;
    }

    private void OnMouseDown()
    {
        initialClickSound.Play();
        InitialPos = transform.position;
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.position = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;

        if (isWalledCounter > 0) // Only trigger return logic when colliding with walls
        {
            failClickSound.Play();
            transform.position = InitialPos;
        }
        else
        {
            finalClickSound.Play();
        }

        winCondition.Winning();
        dragEndedCallback(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Selectable")
        {
            isWalledCounter += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D exit)
    {
        if (exit.gameObject.tag == "Wall" || exit.gameObject.tag == "Selectable")
        {
            isWalledCounter -= 1;
        }
    }

    public int Walled()
    {
        return isWalledCounter;
    }
}
