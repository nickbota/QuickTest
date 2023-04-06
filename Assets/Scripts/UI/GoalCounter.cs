using UnityEngine;
using System.Collections.Generic;

public class GoalCounter : TextCounter
{
    private List<Transform> hiddenObjects = new List<Transform>();
    private int totalHiddenObjects = 6;

    private void OnEnable()
    {
        ObjectDetection.OnObjectFound += OnObjectFound;
    }
    private void OnDisable()
    {
        ObjectDetection.OnObjectFound -= OnObjectFound;
    }

    private void OnObjectFound(Transform foundObject)
    {
        if (hiddenObjects.Contains(foundObject)) return;

        hiddenObjects.Add(foundObject);

        if (hiddenObjects.Count < totalHiddenObjects)
            UpdateCounter($"HIDDEN OBJECTS FOUND {hiddenObjects.Count}/{totalHiddenObjects}", Color.white);
        else
            UpdateCounter("YOU WIN!", Color.green);
    }
}