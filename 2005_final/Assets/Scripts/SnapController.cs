using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public float snapRange = 250;

    GameObject[] draggable_Uptade;

    void Update()
    {
        draggable_Uptade = GameObject.FindGameObjectsWithTag("Building");

        foreach (GameObject draggable in draggable_Uptade)
        {
            OnDragEnded(draggable);
        }
    }

    void OnDragEnded(GameObject draggable)
    {
        float closestDistance = -1;
        Transform closestSnapPoit = null;

        foreach (Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if (closestSnapPoit == null || currentDistance < closestDistance)
            {
                closestSnapPoit = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (closestSnapPoit != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoit.localPosition;
        }
    }
}