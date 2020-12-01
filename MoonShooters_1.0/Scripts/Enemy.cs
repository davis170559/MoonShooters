using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float healthPoints = 4.0f;
    
    private SpawnManager spawnScript;
    private AudioSource audioSource;
    public AudioClip explosionClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) //Reduce hp when hit
    {
        if (other.CompareTag("PlayerBullet"))
        {
            healthPoints -= 1.0f;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("MiniPlayerBullet"))
        {
            healthPoints -= .7f; //6 shoots to die
            Destroy(other.gameObject);
        }

        if (healthPoints <= 0) //Dies at 0
        {
            audioSource.PlayOneShot(explosionClip);
            Destroy(this.gameObject);
            
            
        }
    }
}
