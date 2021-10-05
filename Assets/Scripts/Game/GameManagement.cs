using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using gs = GameStateEnum.GameState; 

public class GameManagement : MonoBehaviour
{

    public GameObject Player;
    public GameObject DeathUI;
    public GameObject WonUI;
    public GameObject PauseUI;

    public int levelIndex;
    public static bool isGamePaused;
    public static bool gameWon;

    public bool popUP;

    public static int levelcount = 8;

    public float deathBoxY = -4f;

    public SoundManager sm;

    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        

        isGamePaused = false;
        gameWon = false;

        sm.switchGameState(gs.Play);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameWon)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !popUP)
            {
                isGamePaused = !isGamePaused;
                PauseUI.SetActive(isGamePaused);
                if (isGamePaused){
                    sm.pause();
                } else {
                    sm.unpause();
                }
            }
            if (Input.GetKey(KeyCode.R))
            {
                //sm.switchGameState(gs.Play);
                Scene scene = SceneManager.GetActiveScene(); 
                SceneManager.LoadScene(scene.name);
            }
            if (!isGamePaused)
            {
                if (Player.transform.position.y < deathBoxY)
                {
                    GameLost();
                }
            } 
        }
        else
        {
            if (levelIndex != levelcount)
            {
                if (Input.GetKey(KeyCode.Return))
                {
                    levelIndex++;
                    sm.switchGameState(gs.Play);
                    SceneManager.LoadScene(levelIndex);
                }
            }
        }
    }

    public void updatePopUp()
    {
        popUP = !popUP;
    }

    public void SkipLevel()
    {
        isGamePaused = false;
        GameWon();
    }
    public void GameWon()
    {
        if (!isGamePaused)
        {
            sm.switchGameState(gs.Win);
            gameWon = true;
            isGamePaused = true;
            WonUI.SetActive(true);
        }
    }

    public void GameLost()
    {
        if (!isGamePaused)
        {
            //Destroy for now
            Destroy(Player, 0.1f);


            gameWon = false;
            isGamePaused = true;
            DeathUI.SetActive(true);
            sm.switchGameState(gs.Loss);
            Debug.Log("Game Lost");
        }
    }
}
