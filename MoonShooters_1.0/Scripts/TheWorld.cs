using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : MonoBehaviour
{
    private bool zaWarudo;
    private float zaWarudoTime;
    private Animator lightAnimator;
    private GameManager gameManager;
     //Start is called before the first frame update
    void Start()
    {
        //Gets components
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        lightAnimator = GameObject.Find("Directional Light").GetComponent<Animator>();
        //Sets the zaWarudo to their initial values
        zaWarudoTime = 0.0f;
        zaWarudo = false;
    }

     //Update is called once per frame
    void Update()
    {
        if (zaWarudo == false)
        {
            if (zaWarudoTime >= 1.5f) //Allows to active the Zawarudo if zawarudo isn't active and zaWarudoTime is greater than 1.5 
            {
                if (Input.GetKeyDown(KeyCode.Space)) 
                {
                    zaWarudo = true;
                    lightAnimator.SetBool("Zawarudo", true);
                    Time.timeScale = 0.5f; 
                }

            }
        }
        if (zaWarudo && zaWarudoTime > 0f)
        {
            zaWarudoTime -= Time.deltaTime; //Timer Countdown
        }
        else
        {

            if (zaWarudo && zaWarudoTime <= 0.001f) //If the time has finished
            {
                zaWarudo = false;
                Time.timeScale = 1.0f;
                lightAnimator.SetBool("Zawarudo", false);
            }
            else
            {
                if (zaWarudoTime < 3) //If the time has´nt reached its limit
                {
                    zaWarudoTime += Time.deltaTime / 10f;
                }
            }
        }
        //Updates the Text on Screen
        gameManager.UpdateZawarudo(zaWarudoTime, zaWarudo);

    }
}
