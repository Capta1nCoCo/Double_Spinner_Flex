using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFigure : MonoBehaviour
{
    [SerializeField] float delayBeforeDestruction = 5f;
    DestructibleObject[] destructibleObjects;

    private void Awake()
    {
        destructibleObjects = GetComponentsInChildren<DestructibleObject>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(delayBeforeDestruction);
        foreach (DestructibleObject destructible in destructibleObjects)
        {
            destructible.ForFinalDestruction();
        }
    }
}
