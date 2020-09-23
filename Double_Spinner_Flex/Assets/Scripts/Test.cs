using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    SpinnerController spinnerController;

    private void Start()
    {
        spinnerController =  FindObjectOfType<SpinnerController>();
    }

    // Update is called once per frame
    void Update()
    {
        var rayPos = spinnerController.TestingRayPosition();
        transform.position = new Vector3(transform.position.x, transform.position.y, rayPos + 25f);
    }
}
