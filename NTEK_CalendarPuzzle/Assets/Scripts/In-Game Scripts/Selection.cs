using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selection : MonoBehaviour
{
    public Color highlightColor;
    public Color selectionColor;

    private Color originalColorHighlight;
    private Color originalColorSelection;
    private Transform highlight;
    private Transform selection;
    private RaycastHit2D raycastHit;

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.GetComponent<SpriteRenderer>().color = originalColorHighlight;
            highlight = null;
        }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        raycastHit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (!EventSystem.current.IsPointerOverGameObject() && raycastHit.collider != null)
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") && highlight != selection)
            {
                if (highlight.GetComponent<SpriteRenderer>().color != highlightColor)
                {
                    originalColorHighlight = highlight.GetComponent<SpriteRenderer>().color;
                    highlight.GetComponent<SpriteRenderer>().color = highlightColor;
                }
            }
            else
            {
                highlight = null;
            }
        }

        // Selection
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (highlight)
            {
                if (selection != null)
                {
                    selection.GetComponent<SpriteRenderer>().color = originalColorSelection;
                }
                selection = raycastHit.transform;
                if (selection.GetComponent<SpriteRenderer>().color != selectionColor)
                {
                    originalColorSelection = originalColorHighlight;
                    selection.GetComponent<SpriteRenderer>().color = selectionColor;
                }
                highlight = null;
            }
            else
            {
                if (selection)
                {
                    selection.GetComponent<SpriteRenderer>().color = originalColorSelection;
                    selection = null;
                }
            }
        }
    }
}
