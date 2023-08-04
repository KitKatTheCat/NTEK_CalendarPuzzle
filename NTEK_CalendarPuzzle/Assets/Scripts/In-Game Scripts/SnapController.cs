using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Dragging> draggingObjects;
    public float snapRange = 0.5f;

    private void Start()
    {
        foreach (Dragging dragging in draggingObjects)
        {
            dragging.dragEndedCallback = OnDragEnded;
        }
    }

    private void Update()
    {
        // Loop through all the dragging objects and check for collisions
        foreach (Dragging dragging in draggingObjects)
        {
            CheckCollisions(dragging);
        }
    }

    private void OnDragEnded(Dragging dragging)
    {
        if (!dragging.IsDragged) // Check if the piece is not being dragged
        {
            // Check for collisions for the specific dragging object
            CheckCollisions(dragging);
        }
    }

    private void CheckCollisions(Dragging dragging)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(dragging.transform.position, snapPoint.position);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            // Check for colliding objects using PolygonCollider2D
            PolygonCollider2D pieceCollider = dragging.GetComponent<PolygonCollider2D>();
            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.useTriggers = false;
            Collider2D[] results = new Collider2D[5]; // Adjust the size based on the expected number of collisions

            int numCollisions = pieceCollider.OverlapCollider(contactFilter, results);

            // Check if any of the colliders are occupied snap points
            bool isSnapPointOccupied = false;
            for (int i = 0; i < numCollisions; i++)
            {
                if (snapPoints.Contains(results[i].transform))
                {
                    isSnapPointOccupied = true;
                    break;
                }
            }

            if (!isSnapPointOccupied)
            {
                dragging.transform.position = closestSnapPoint.position;
            }
            else
            {
                // Snap point is occupied, move the dragged piece back to its initial position
                dragging.transform.position = dragging.InitialPos;
            }
        }
    }
}
