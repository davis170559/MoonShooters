using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private SpawnManager spawnManager;

    private float hp = 600;
    private int phase;

    private Animator bossAnimator;
    private GameManager gameManager;
    private AudioSource audioSource;
    public AudioClip explosionClip;
    // Start is called before the first frame update
    void Start()
    {
        //Gets components
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        bossAnimator = GetComponent<Animator>();
        
        phase = 0;
        bossAnimator.SetInteger("Phase", phase);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(int damage) //function will be called by sons (the torrets)
    {
        hp -= damage;
        if (hp <= 0) //dies
        {
            audioSource.PlayOneShot(explosionClip, .4f);
            gameManager.GameEnd();
            Destroy(this.gameObject);
            
        }
        if (hp <= 400 && phase == 0) //Phase 1
        {
            phase = 1;
            bossAnimator.SetInteger("Phase", phase);
        }
        if (hp <= 300 && phase == 1) //Phase 2
        {
            phase = 2;
            bossAnimator.SetInteger("Phase", phase);
        }


    }
   
}
