using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionResponce : MonoBehaviour,ISelectionResponce
{
    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Transform>();
        if (selectionRenderer != null)
        {
            Debug.Log("deselktovan");
        }
    }

    public void OnSelect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Transform>();
        if (selectionRenderer != null)
        {
            Debug.Log("selectovan");
        }
    }

}
