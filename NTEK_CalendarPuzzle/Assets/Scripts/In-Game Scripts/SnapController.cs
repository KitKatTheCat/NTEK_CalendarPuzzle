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

    private void OnDragEnded(Dragging dragging)
    {
        if (!dragging.IsDragged) // Check if the piece is not being dragged
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
                // Check if the closest snap point is occupied by another piece
                bool isSnapPointOccupied = IsSnapPointOccupied(closestSnapPoint);

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

    private bool IsSnapPointOccupied(Transform snapPoint)
    {
        foreach (Dragging dragging in draggingObjects)
        {
            if (dragging.transform.position == snapPoint.position && dragging != null)
            {
                return true;
            }
        }
        return false;
    }

}
