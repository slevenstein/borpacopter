using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_MobGrinder_Fight : MonoBehaviour
{                                   
    public GameObject qynoa;        
    public GameObject johnSouls;    
    public GameObject racc;

    public AudioClip ow;
    public Sprite baldSprite;

    public Slider hpBar;

    int phase;

    int counter = 0;

    float immuneTimer = 0;
    bool dmgImmune = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Goo" && !dmgImmune)
        {
            AudioSource.PlayClipAtPoint(ow, transform.position, 20f);
            StartCoroutine("hitColor");
            dmgImmune = true;
            immuneTimer = 1f;
            counter++;
            Debug.Log("goo shot: " + counter);
            hpBar.value--;
            if(counter == 3)
            {
                phase = 2;
            }
            //update the slider cause im lasy to do it automatically
            else if(counter >= 12)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = baldSprite;
                Debug.Log("phase3");
                phase = 3;
                GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagement>().GameWon();
            }
        }
    }

    IEnumerator hitColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f, 1);
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }

    private void Update()
    {
        if (dmgImmune)
        {
            immuneTimer -= Time.deltaTime % 60;
        }
        if (immuneTimer <= 0)
        {
            dmgImmune = false;
        }
    }

    private void Start()
    {
        phase = 1;
        StartCoroutine("BossLoop");
    }

    public void updatePhase(int newPhase)
    {
        phase = newPhase;
    }

    private void spawnRacc(bool moveLeft, float xPos, float yPos)
    {
        GameObject spawnRacc = GameObject.Instantiate(racc, new Vector3(xPos, yPos, .1f), new Quaternion(0f, 0f, 0f, 0f));
        if (moveLeft)
        {
            spawnRacc.GetComponent<Racc_Behavior>().moveLeft = moveLeft;
        }
    }

    private void spawnJohn(bool moveLeft, float xPos, float yPos)
    {
        GameObject spawnJohn = GameObject.Instantiate(johnSouls, new Vector3(xPos, yPos, .1f), new Quaternion(0f, 0f, 0f, 0f));
        if (moveLeft)
        {
            spawnJohn.GetComponent<JohnSoulsBehavior>().moveLeft = moveLeft;
        }
    }


    private void spawnQynoa(bool faceRight, float xPos, float yPos)
    {
        GameObject spawnQynoa = GameObject.Instantiate(qynoa, new Vector3(xPos, yPos, .1f), new Quaternion(0f, 0f, 0f, 0f));
        if (faceRight)
        {
            spawnQynoa.GetComponent<qynoa_behavior>().faceRight = faceRight;
        }
    }

    IEnumerator BossLoop()
    {
        while(phase == 1)
        {
            //spawn left Racc
            spawnRacc(true, -1, 8);
            spawnRacc(true, 0, 8);
            spawnRacc(true, 1, 8);
            spawnRacc(true, 2, 8);
            spawnRacc(true, 3, 8);
            spawnRacc(true, 4, 8);
            yield return new WaitForSeconds(3f);

            //triplespawn left
            spawnRacc(true, -2, 8);
            spawnRacc(true, -1, 8);
            spawnRacc(true, 0, 8);
            spawnRacc(true, 1, 8);
            spawnRacc(true, 2, 8);
            spawnRacc(true, 3, 8);
            spawnRacc(true, 4, 8);
            spawnRacc(true, 5, 8);
            yield return new WaitForSeconds(.5f);
            spawnRacc(true, -2.5f, 8);
            spawnRacc(true, -1.5f, 8);
            spawnRacc(true, -.5f, 8);
            spawnRacc(true, 0.5f, 8);
            spawnRacc(true, 1.5f, 8);
            spawnRacc(true, 2.5f, 8);
            spawnRacc(true, 3.5f, 8);
            spawnRacc(true, 4.5f, 8);
            spawnRacc(true, 5.5f, 8);
            yield return new WaitForSeconds(.5f);
            spawnRacc(true, -2, 8);
            spawnRacc(true, -1, 8);
            spawnRacc(true, 0, 8);
            spawnRacc(true, 1, 8);
            spawnRacc(true, 2, 8);
            spawnRacc(true, 3, 8);
            spawnRacc(true, 4, 8);
            spawnRacc(true, 5, 8);
            yield return new WaitForSeconds(1.5f);

            //triplespawn left
            spawnRacc(true, -2, 8);
            spawnRacc(true, -1, 8);
            spawnRacc(true, 0, 8);
            spawnRacc(true, 1, 8);
            spawnRacc(true, 2, 8);
            spawnRacc(true, 3, 8);
            spawnRacc(true, 4, 8);
            spawnRacc(true, 5, 8);
            yield return new WaitForSeconds(.5f);
            spawnRacc(true, -2.5f, 8);
            spawnRacc(true, -1.5f, 8);
            spawnRacc(true, -.5f, 8);
            spawnRacc(true, 0.5f, 8);
            spawnRacc(true, 1.5f, 8);
            spawnRacc(true, 2.5f, 8);
            spawnRacc(true, 3.5f, 8);
            spawnRacc(true, 4.5f, 8);
            spawnRacc(true, 5.5f, 8);
            yield return new WaitForSeconds(.5f);
            spawnRacc(true, -2, 8);
            spawnRacc(true, -1, 8);
            spawnRacc(true, 0, 8);
            spawnRacc(true, 1, 8);
            spawnRacc(true, 2, 8);
            spawnRacc(true, 3, 8);
            spawnRacc(true, 4, 8);
            spawnRacc(true, 5, 8);
            yield return new WaitForSeconds(1.5f);

            //spawn right
            spawnRacc(false, 1, 8);
            spawnRacc(false, 2, 8);
            spawnRacc(false, 3, 8);
            spawnRacc(false, 4, 8);
            spawnRacc(false, 5, 8);
            spawnRacc(false, 6, 8);
            yield return new WaitForSeconds(3f);

            //triplespawn right
            spawnRacc(false, 0, 8);
            spawnRacc(false, 1, 8);
            spawnRacc(false, 2, 8);
            spawnRacc(false, 3, 8);
            spawnRacc(false, 4, 8);
            spawnRacc(false, 5, 8);
            spawnRacc(false, 6, 8);
            spawnRacc(false, 7, 8);
            yield return new WaitForSeconds(.5f);
            spawnRacc(false, 0.5f, 8);
            spawnRacc(false, 1.5f, 8);
            spawnRacc(false, 2.5f, 8);
            spawnRacc(false, 3.5f, 8);
            spawnRacc(false, 4.5f, 8);
            spawnRacc(false, 5.5f, 8);
            spawnRacc(false, 6.5f, 8);
            spawnRacc(false, 7.5f, 8);
            yield return new WaitForSeconds(.5f);
            spawnRacc(false, 0, 8);
            spawnRacc(false, 1, 8);
            spawnRacc(false, 2, 8);
            spawnRacc(false, 3, 8);
            spawnRacc(false, 4, 8);
            spawnRacc(false, 5, 8);
            spawnRacc(false, 6, 8);
            spawnRacc(false, 7, 8);
            yield return new WaitForSeconds(1.5f);

            //triplespawn right
            spawnRacc(false, 0, 8);
            spawnRacc(false, 1, 8);
            spawnRacc(false, 2, 8);
            spawnRacc(false, 3, 8);
            spawnRacc(false, 4, 8);
            spawnRacc(false, 5, 8);
            spawnRacc(false, 6, 8);
            spawnRacc(false, 7, 8);
            yield return new WaitForSeconds(.5f);
            spawnRacc(false, 0.5f, 8);
            spawnRacc(false, 1.5f, 8);
            spawnRacc(false, 2.5f, 8);
            spawnRacc(false, 3.5f, 8);
            spawnRacc(false, 4.5f, 8);
            spawnRacc(false, 5.5f, 8);
            spawnRacc(false, 6.5f, 8);
            spawnRacc(false, 7.5f, 8);
            yield return new WaitForSeconds(.5f);
            spawnRacc(false, 0, 8);
            spawnRacc(false, 1, 8);
            spawnRacc(false, 2, 8);
            spawnRacc(false, 3, 8);
            spawnRacc(false, 4, 8);
            spawnRacc(false, 5, 8);
            spawnRacc(false, 6, 8);
            spawnRacc(false, 7, 8);
            yield return new WaitForSeconds(1.5f);
        }
        //spawn john
        StartCoroutine("JohnPlace");

        while (phase == 2)
        {

            //spawn left Racc
            spawnRacc(true, -1, 8);
            spawnRacc(true, 0, 8);
            spawnRacc(true, 1, 8);
            spawnRacc(true, 2, 8);
            spawnRacc(true, 3, 8);
            yield return new WaitForSeconds(1.5f);

            //spawn right
            spawnRacc(false, 2, 8);
            spawnRacc(false, 3, 8);
            spawnRacc(false, 4, 8);
            spawnRacc(false, 5, 8);
            spawnRacc(false, 6, 8);
            yield return new WaitForSeconds(1.5f);

            //spawn left qynoa
            spawnQynoa(true, -5.75f, 0.15f);
            yield return new WaitForSeconds(1.5f);

            //spawn right qynoa
            spawnQynoa(false, 10.75f, 0.15f); ;
            yield return new WaitForSeconds(1.5f);



            //triplespawn left
            spawnRacc(true, -1, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 0, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 1, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 2, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 3, 8);
            
            spawnRacc(true, -1.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, -.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 0.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 1.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 2.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 3.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, -1, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 0, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 1, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 2, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(true, 3, 8);
            yield return new WaitForSeconds(2f);

            spawnQynoa(true, -5.5f, 0.15f);
            yield return new WaitForSeconds(.5f);

            //triplespawn right

            spawnRacc(false, 7, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 6, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 5, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 4, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 3, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 2, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 1, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 0, 8);
            yield return new WaitForSeconds(.1f);

            spawnRacc(false, 7.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 6.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 5.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 4.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 3.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 2.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 1.5f, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 0.5f, 8);
            yield return new WaitForSeconds(.1f);

            spawnRacc(false, 7, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 6, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 5, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 4, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 3, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 2, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 1, 8);
            yield return new WaitForSeconds(.1f);
            spawnRacc(false, 0, 8);

            yield return new WaitForSeconds(2f);

            spawnQynoa(false, 10.5f, 0.15f); ;
            yield return new WaitForSeconds(.5f);
        }
        Debug.Log("Won");
    }

    IEnumerator JohnPlace()
    {
        spawnJohn(false, -13, .5f);
        yield return new WaitForSeconds(5f);
        spawnJohn(true, 18, .5f);
    }
}
