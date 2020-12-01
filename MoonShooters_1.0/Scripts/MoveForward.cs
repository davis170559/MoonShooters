using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    public float screenTime;
    public bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        screenTime -= Time.deltaTime; //Countdown
        if (screenTime <= 0) //Destroys the bullet after the specified time
        {
            Destroy(this.gameObject);
        }
        if(isPlayer) //If its a player bullet, it will ignore the Zawarudo, else it wont
        transform.Translate(Vector3.forward * Time.deltaTime * speed /Time.timeScale);
        else
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
