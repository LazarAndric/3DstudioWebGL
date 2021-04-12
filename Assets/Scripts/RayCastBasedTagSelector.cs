using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastBasedTagSelector : MonoBehaviour,ISelector
{
    [SerializeField] public string selectableTag = "Selectable";
    public Transform _selection;

    public void Check(Ray ray)
    {


        _selection = null;
        if (!Physics.Raycast(ray, out var hit)) return;

        var selection = hit.transform;
        if (selection.CompareTag(selectableTag))
        {
            _selection = selection;
        }

        
    }

    public Transform GetSelection()
    {
        return this._selection;
    }
}
