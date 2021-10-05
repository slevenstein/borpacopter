using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementTrigger : MonoBehaviour
{
    public int triggerPosition = 1;

    public GameObject boss;

    private BossBehavior bb;
    private void Start()
    {
        bb = boss.GetComponent<BossBehavior>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {        
        if(col.tag == "Player")
        {
            bb.bossMovement = triggerPosition;
        }
    }
}
