using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private Transform _currentSelection;
    
    ISelectionResponce selectionResponce;
    IRayProvider _rayProvider;
    ISelector _selector;


    private void Awake()
    {
        selectionResponce = GetComponent<ISelectionResponce>();
        _rayProvider = GetComponent<IRayProvider>();
        _selector = GetComponent<ISelector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_currentSelection != null)
        {
            selectionResponce.OnDeselect(_currentSelection);
        }

        _selector.Check(_rayProvider.CreateRay());
        _currentSelection = _selector.GetSelection();

        if(_currentSelection != null)
        {
            selectionResponce.OnSelect(_currentSelection);
        }
    }

}
