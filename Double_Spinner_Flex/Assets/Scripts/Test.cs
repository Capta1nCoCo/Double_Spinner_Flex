using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Transform scorePopUp;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(scorePopUp, transform.position, Quaternion.identity);
    }
    
}
