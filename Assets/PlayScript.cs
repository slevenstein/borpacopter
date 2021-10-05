using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public int levelIndex = 0;


    public void PlayGame()
    {
        levelIndex++;
        SceneManager.LoadScene(levelIndex);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
