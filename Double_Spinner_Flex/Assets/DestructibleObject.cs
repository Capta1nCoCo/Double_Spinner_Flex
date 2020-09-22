using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [Header("Explosion Properties")]
    [SerializeField] float explosionForce = 500f;
    [SerializeField] float explosionRadius = 2f;

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
                    rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }
        }
    }
}
