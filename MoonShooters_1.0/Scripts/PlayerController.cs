using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player movement 
    private float speed = 10.0f;
    private float horizontalInput;
    private Animator playerAnimator;
    private float verticalInput;
    //bullets
    public GameObject projectilPrefab;
    public GameObject miniProjectilPrefab;
    //Walls' position
    private float xRange = 30.0f;
    private float lowerBound = -24.0f;
    private float topBound = 14.2f;
    //Used as reference to prevent the player from spamming bullets
    private float balas;

    private GameManager gameManager;
    private AudioSource audioSource;
    public AudioClip shootClip;
    public AudioClip explosionClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        balas = 1.0f; //Set balas 
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //To move the player
        Vector3 move = new Vector3();
        if (Input.GetKey(KeyCode.A)) move.x = -1;
        else if (Input.GetKey(KeyCode.D)) move.x = 1;
        if (Input.GetKey(KeyCode.S)) move.z = -1;
        else if (Input.GetKey(KeyCode.W)) move.z = 1;

        transform.Translate(move * Time.deltaTime * speed / Time.timeScale, null); //Actual movement of the player

        //Prevents the player from going out of bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < lowerBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, lowerBound);
        }
        if (transform.position.z > topBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, topBound);
        }
        

        //animation control
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            triggerAnimation(1);
            speed = 14f;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            triggerAnimation(0);
            speed = 10f;
        }
        
        //Shooting
        if (Input.GetKey(KeyCode.Mouse0) && balas >= 2.0f)
        {
            
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("minimize"))
            {
                balas -= 2.0f;
                Instantiate(miniProjectilPrefab, transform.position, transform.rotation);
                audioSource.PlayOneShot(shootClip,.15f);
            }
            else
            {
                balas -= 2.0f;
                Instantiate(projectilPrefab, transform.position, transform.rotation);
                audioSource.PlayOneShot(shootClip, .3f);
            }

        }
        //Bala's variable sets a limit to the shoots' frecuency. (2.0/.5= 4, one shoot every 4 frames) 
        if (balas < 2.0f)
        {
            balas += .5f;
        }
    }
    private void triggerAnimation(int change)
    {
        playerAnimator.SetInteger("changeScale", change);
        
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        //When touches a enemy bullet, enemy or boss
        if (other.CompareTag("EnemyBullet") || other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            gameManager.GameOver(); //Ends the game when the player is dead
            audioSource.PlayOneShot(explosionClip,.4f);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
   
}
