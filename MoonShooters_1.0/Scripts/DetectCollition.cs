using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollition : MonoBehaviour
{
    private int hp=2;
    private Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        if (this.CompareTag("Boss"))
        {
            boss = GameObject.Find("Boss(Clone)").GetComponent<Boss>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) //If this script belogns to the boss, it will call a function on parent's script to reduce hp
    {
        if (other.CompareTag("PlayerBullet"))
        {
            if (this.CompareTag("Boss"))
            {
                boss.Damage(2);
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
            
        }
        if (other.CompareTag("MiniPlayerBullet"))
        {
            if (this.CompareTag("Boss"))
            {
                boss.Damage(1);
                Destroy(other.gameObject);
            }
            else
            {
                hp--;
                Destroy(other.gameObject);
            }
        } 
        if(hp<=0) Destroy(this.gameObject);
    }
    
}
