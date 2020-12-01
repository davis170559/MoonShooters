using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFire : MonoBehaviour
{
    public GameObject projectilPrefab;
    public float delay;
    public float waitTime;
    private AudioSource audioSource;
    public AudioClip shootClip;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("Fire"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Fire()
    {
        while (true)
        {
            audioSource.PlayOneShot(shootClip, .3f); //Sound
            Instantiate(projectilPrefab, transform.position, transform.rotation*Quaternion.Euler(0, delay, 0));
            yield return new WaitForSeconds(waitTime);
        }
    }
}
