using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int life = 100;
    private int highscore;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(life <= 0) {
            //TODO: game over, add meniu for restart and lose message
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public int GetHighscore() {
        return highscore;
    }

    public void AddHighscore(int points) {
        highscore += points;
    }
}
