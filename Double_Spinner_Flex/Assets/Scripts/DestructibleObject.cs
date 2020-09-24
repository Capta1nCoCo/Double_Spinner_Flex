using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [Header("Delays (in seconds)")]
    [SerializeField] float delayBeforeExplosion = 0.17f;
    [SerializeField] float delayBeforeRemoval = 0.4f;

    [Header("Explosion Properties")]
    [SerializeField] float explosionForceMin = 40f;
    [SerializeField] float explosionForceMax = 70f;
    [SerializeField] float explosionRadius = 30f;
    

    Rigidbody[] allRigidBodies;
    ScorePopup scorePopup;

    private void Awake()
    {
        allRigidBodies = GetComponentsInChildren<Rigidbody>();
        scorePopup = GetComponent<ScorePopup>();
    }        

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            scorePopup.PopUpScoreNumber();
            Destroy(GetComponent<BoxCollider>());
            StartCoroutine(WaitAndExplode());
            Destroy(gameObject, 2f);
        }
    }

    IEnumerator WaitAndExplode()
    {
        yield return new WaitForSeconds(delayBeforeExplosion);
        foreach (Rigidbody rigidbody in allRigidBodies)
        {
            if(rigidbody != null)
            {
                rigidbody.useGravity = true;
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
