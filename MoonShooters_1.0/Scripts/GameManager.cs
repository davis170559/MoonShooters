using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //Text and buttons on screen
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI zawarudoText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI congratText;
    public TextMeshProUGUI pauseText;
    public TextMeshProUGUI instructionsText;
    public Button restartButton;
    public TextMeshProUGUI titleText;
    public Button startButton;

    public bool isGameActive;
    public GameObject player;
    private float waveNumber;
    private bool pause;
    // Start is called before the first frame update
    void Start()
    {
        pause = false;
        Time.timeScale = 1.0f;
        isGameActive = true;
        //Texts
        titleText.gameObject.SetActive(false);
        instructionsText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        zawarudoText.gameObject.SetActive(true);
        waveText.gameObject.SetActive(true);
      
        player.SetActive(true);
    }
    public void UpdateZawarudo(float value, bool isActive)
    {
        //Only one path should write Press Space
        if (isActive)
        {
            zawarudoText.text = "The World: " + value.ToString("F2") + "(s)";
        }
        else
        {
            if (value > 1.5)
            {
                zawarudoText.text = "The World: " + value.ToString("F2") + "(s)\n Press Space";
            }
            else
            {
                zawarudoText.text = "The World: " + value.ToString("F2") + "(s)";
            }
        }
        
    }
    public void UpdateWaveText(float value)
    {

        waveText.text = "Wave " + value + " of 8";
    }
    
    // Update is called once per frame
    void Update()
    {
        //If esc is pressed and !pause, it'll pause, else it'll unpause
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!pause)
            {
                pause = true;
                Time.timeScale = 0f;
                player.GetComponent<PlayerController>().enabled = false;
                pauseText.gameObject.SetActive(true);
            }
            else
            {
                pause = false;
                Time.timeScale = 1.0f;
                player.GetComponent<PlayerController>().enabled = true;
                pauseText.gameObject.SetActive(false);
            }
        }
    }
    
    public void GameEnd() //Player won
    {
        Time.timeScale = 0f;
        isGameActive = false;
        congratText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

    }
    public void GameOver() //Player lost
    {
        Time.timeScale = 0f;
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
