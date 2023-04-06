using System;
using UnityEngine;

public class ObjectDetection : MonoBehaviour
{
    [SerializeField] private LayerMask objectLayer;
    public static Action<Transform> OnObjectFound;
    private Transform selectedObject;

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hitObject;

        if (Physics.Raycast(ray, out hitObject, Mathf.Infinity, objectLayer))
        {
            if (hitObject.transform.GetComponent<ISelectableObject>() == null) return;

            if (selectedObject != hitObject.transform)
                SelectNewObject(hitObject.transform);
        }
        else
            DeselectObject();
    }

    private void SelectNewObject(Transform newObject)
    {
        OnObjectFound?.Invoke(newObject);
        selectedObject = newObject;

        ISelectableObject[] selectableComponents = selectedObject.GetComponents<ISelectableObject>();
        foreach (ISelectableObject selectableComponent in selectableComponents)
            selectableComponent.OnSelect();
    }
    private void DeselectObject()
    {
        if (selectedObject == null) return;

        ISelectableObject[] selectableComponents = selectedObject.GetComponents<ISelectableObject>();
        foreach (ISelectableObject selectableComponent in selectableComponents)
            selectableComponent.OnDeselect();

        selectedObject = null;
    }
}