using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Destroy(other.gameObject);
        }        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Destroy(other.gameObject);
        }
    }
}
