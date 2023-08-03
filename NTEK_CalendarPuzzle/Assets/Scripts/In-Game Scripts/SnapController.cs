using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<Dragging> DraggingObjects;
    public float snapRange = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Dragging dragging in DraggingObjects)
        {
            dragging.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(Dragging dragging)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach(Transform snapPoint in snapPoints)
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
            dragging.transform.position = closestSnapPoint.position;
        }
    }
}