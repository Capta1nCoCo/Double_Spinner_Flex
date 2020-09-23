using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerController : MonoBehaviour
{    
    [SerializeField] Transform spinnerRed;
    [SerializeField] Transform spinnerYellow;
    [SerializeField] float speedModifier = 0.015f;
    [SerializeField] float zRayOffset = 35f;
    
    Touch touch;

    float xPadding = 8f;    
    float zMin, zMax;
    

    // Update is called once per frame
    void Update()
    {
        SetUpMoveBoundaries();
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                ProcessTranslation(touch);
                //spinnerRed.position = new Vector3(
                //    spinnerRed.position.x + touch.deltaPosition.x * speedModifier,
                //    spinnerRed.position.y,
                //    spinnerRed.position.z + touch.deltaPosition.y * speedModifier);
            }
        }
    }

    private void ProcessTranslation(Touch touch)
    {

        var deltaX = touch.deltaPosition.x * speedModifier;
        var deltaZ = touch.deltaPosition.y * speedModifier;

        // PC Controls:
        //var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var rawXPos = spinnerRed.position.x + deltaX;
        var rawZPos = spinnerRed.position.z + deltaZ;

        float clampedXPos = Mathf.Clamp(rawXPos, -xPadding, xPadding);
        float clampedZPos = Mathf.Clamp(rawZPos, zMin, zMax);

        spinnerRed.position = new Vector3(clampedXPos, spinnerRed.position.y, clampedZPos);
    }

    private void SetUpMoveBoundaries()
    {
        // for Z movement
        Camera gameCamera = Camera.main;
                
        float yMinToWorld = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;      

        Ray zMinRay = gameCamera.ScreenPointToRay(new Vector3(0, 0, yMinToWorld));
        zMin = zMinRay.origin.z;
        zMax = zMinRay.origin.z + zRayOffset;
    }   

}
