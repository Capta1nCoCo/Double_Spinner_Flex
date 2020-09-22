using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Transform rightSpinner;
    
    Vector3 touchPosition;
    Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            //touchPosition.z = 0; //are you shure about that?
            direction = touchPosition - transform.position;
            Debug.Log(touchPosition);
            //rigidbody3D.velocity = new Vector3(direction.x, direction.y) * speed;

            //if (touch.phase == TouchPhase.Ended)
            //{
            //    rigidbody3D.velocity = Vector3.zero;
            //}
        }
    }
}
