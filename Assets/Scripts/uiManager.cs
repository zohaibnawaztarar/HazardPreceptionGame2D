using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour
{
    public Button[] buttons; // array for buttons after game over
    public Text scoreText;
    bool gameOver;
    int score;
    public audioManager am;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score;
        
        //score += 1;
    }

    void scoreUpdate()
    {
        if (gameOver == false)
        {
            score += 1;
        }
        
    }

    public void gameOverActivated()
    {
        gameOver = true;

        // Activate buttons after game is over
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("level1");
        //Application.LoadLevel("level1");
    }

    public void Pause()
    {
        if (gameOver) return; // pause only if game is not over

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            am.carSound.Stop ();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            am.carSound.Play ();

        }

    }

    public void Replay()
    {
        Application.LoadLevel (Application.loadedLevel);
    }

    public void mainMenu()
    {
        Application.LoadLevel("menu");
    }
    
    public void Exit()
    {
        Application.Quit ();
    }
    
}
