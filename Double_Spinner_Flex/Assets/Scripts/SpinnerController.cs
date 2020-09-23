using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerController : MonoBehaviour
{    
    [SerializeField] Transform spinnerRed;
    [SerializeField] Transform spinnerYellow;
    [SerializeField] float speedModifier = 0.015f;
    [SerializeField] float zRayOffset = 30f;
    
    Touch touch;    

    float xMin, xMax, yMin, yMax;
    Ray xMinRay, xMaxRay, zMinRay, zMaxRay;
    float xMinInWorld, xMaxInWorld, zMinInWorld, zMaxInWorld;

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

        float clampedXPos = Mathf.Clamp(rawXPos, xMin, xMax);
        float clampedZPos = Mathf.Clamp(rawZPos, zMinInWorld, zMaxInWorld);

        spinnerRed.position = new Vector3(rawXPos, spinnerRed.position.y, clampedZPos);
    }

    private void SetUpMoveBoundaries()
    {
        // updated coordinates for X and Z in the Word of spinners related to the Screen
        Camera gameCamera = Camera.main;
        
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        xMinRay = gameCamera.ScreenPointToRay(new Vector3(xMin, 0, 0));
        xMaxRay = gameCamera.ScreenPointToRay(new Vector3(xMax, 0, 0));

        zMinRay = gameCamera.ScreenPointToRay(new Vector3(0, 0, yMin));
        zMinInWorld = zMinRay.origin.z;
        zMaxInWorld = zMinRay.origin.z + zRayOffset;


        Debug.Log("Z min: " + xMinRay.origin.z + "Z Max: " + xMaxRay.origin.z);
    }

    public float TestingRayPosition()
    {
        return zMinRay.origin.z;
    }

}
