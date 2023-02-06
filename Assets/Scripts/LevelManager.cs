using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;

    [SerializeField] float sceneLoadDelay = 3f;
    

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();  
    }
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
        //audioPlayer.GetInstance().AudioSourceGame();
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        //audioPlayer.GetInstance().AudioSourceMain();
    }

    public void LoadGameOver()
    {
        StartCoroutine(EndGame("GameOver", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game.");
        Application.Quit();
    }

    IEnumerator EndGame(string sceneName, float delay)
    {
        yield return new WaitForSecondsRealtime (delay);
        SceneManager.LoadScene(sceneName);
        //audioPlayer.GetInstance().AudioSourceEND();
        
    }
}
