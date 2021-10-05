using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    GameObject GameManager;

    public void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManagement.isGamePaused)
        {
            if (collision.tag == "Bad")
            {
                //check for if player can kill
                GameManager.GetComponent<GameManagement>().GameLost();
                //gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            else if (collision.tag == "Win")
            {
                GameManager.GetComponent<GameManagement>().GameWon();
                //gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }
    }
}
