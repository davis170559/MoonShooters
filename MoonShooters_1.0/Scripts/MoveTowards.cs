using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    private float speed = 8.0f;
    public float turnSpeed = 1.0f;
    private GameObject player;
    private Transform playerTransform;
    private float screenTime;
    private bool isEnemy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
        if (this.tag == "Enemy")
        {
            isEnemy = true;
            speed = 4.0f;
        }
        else
        {
            screenTime = 10;
            isEnemy = false;
        }
       
    }

    // Update is called once per frame
    void Update()
    {

        // Determine which direction to rotate towards
        Vector3 targetDirection = playerTransform.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = turnSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        
        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (!isEnemy) 
        {
            screenTime -= Time.deltaTime; //Countdown to destroy the bullet
            if (screenTime <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
    
}
