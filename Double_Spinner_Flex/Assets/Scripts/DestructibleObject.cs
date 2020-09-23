using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [Header("Delays (in seconds)")]
    [SerializeField] float delayBeforeExplosion = 0.4f;
    [SerializeField] float delayBeforeRemoval = 0.4f;

    [Header("Explosion Properties")]
    [SerializeField] float explosionForceMin = 500f;
    [SerializeField] float explosionForceMax = 500f;
    [SerializeField] float explosionRadius = 30f;
    

    Rigidbody[] allRigidBodies;

    private void Awake()
    {
        allRigidBodies = GetComponentsInChildren<Rigidbody>();
    }        

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(GetComponent<BoxCollider>());
            StartCoroutine(WaitAndExplode());            
        }
    }

    IEnumerator WaitAndExplode()
    {
        yield return new WaitForSeconds(delayBeforeExplosion);
        foreach (Rigidbody rigidbody in allRigidBodies)
        {
            if(rigidbody != null)
            {
                rigidbody.AddExplosionForce(Random.Range(explosionForceMin, explosionForceMax), transform.position, explosionRadius);
                StartCoroutine(WaitAndTagAsUsed(rigidbody));
            }            
        }
    }

    IEnumerator WaitAndTagAsUsed(Rigidbody rigidbody)
    {
        yield return new WaitForSeconds(delayBeforeRemoval);
        if(rigidbody != null)
        {
            rigidbody.gameObject.tag = "Used";
        }        
    }
}
