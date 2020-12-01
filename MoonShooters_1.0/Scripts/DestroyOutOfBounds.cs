using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    //Bounds
    private float leftBound = 30.0f;
    private float lowerBound = -24.0f;
    private float topBound = 14.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Bounds reached
        if (transform.position.z > topBound || transform.position.z < lowerBound || transform.position.x > leftBound || transform.position.x < -leftBound)
        {
            Destroy(gameObject);
        }

    }
}
