using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [Header("Explosion Properties")]
    [SerializeField] float explosionForceMin = 500f;
    [SerializeField] float explosionForceMax = 500f;
    [SerializeField] float explosionRadius = 30f;

    Rigidbody[] allRigidBodies;

    private void Awake()
    {
        allRigidBodies = GetComponentsInChildren<Rigidbody>();
    }

    

    void Update()
    {
        //For Testing Purposes
        if (Input.GetButtonDown("Fire1"))
        {
            if(allRigidBodies.Length > 0)
            {
                foreach(Rigidbody rigidbody in allRigidBodies)
                {
                    rigidbody.AddExplosionForce(Random.Range(explosionForceMin, explosionForceMax), transform.position, explosionRadius);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (Rigidbody rigidbody in allRigidBodies)
            {
                if (rigidbody == null) { return; }
                rigidbody.AddExplosionForce(Random.Range(explosionForceMin, explosionForceMax), transform.position, explosionRadius);
                rigidbody.gameObject.tag = "Used";
            }
        }
    }
}
