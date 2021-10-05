using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject bullet_prefab;
    public GameObject spawnPos;
    public float spawnTimer;
    public GameObject poopMap;

    public float health = 10;


    public bool lookAtPlayer;

    GameObject player;

    //public float yeeDamping;
    //public float yeeDistance;
    public float bullet_speed;
    public float bulletLinger;
    float counter;

    public int bossMovement = 1;

    public float speed_1 = 10f;
    public float speed_2 = 10f;
    public float speed_3 = 10f;
    public float speed_4 = 10f;
    public float speed_5 = 10f;
    public float speed_6 = 10f;
    public GameObject target_1;
    public GameObject target_2;
    public GameObject target_3;
    public GameObject target_4;
    public GameObject target_5;
    public GameObject target_6;

    public AudioSource ow;
    public AudioSource laugh;
    public AudioSource shit;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        if (!GameManagement.isGamePaused)
        {
            if (lookAtPlayer)
            {
                //var offset = 180f;
                Vector2 direction = (Vector2)player.transform.position - (Vector2)transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                if(angle <= -90f || angle >= 90f)
                {
                    //look left
                    transform.rotation = Quaternion.Euler(new Vector3(0,180f,0));
                }
                else
                {
                    //look right
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                }
                //spawnPos.transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
            }

            /*counter += Time.deltaTime % 60;

            if (counter >= spawnTimer)
            {
                GameObject bullet = Instantiate(bullet_prefab, spawnPos.transform.position, spawnPos.transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(spawnPos.transform.right * -bullet_speed, ForceMode2D.Impulse);
                bullet.GetComponent<BossBullet>().bulletLinger = bulletLinger;
                counter = 0;
            }*/
        }
    }

    void Update()
    {
        MoveBoss();
    }

    void MoveBoss()
    {
        float step = speed_1 * Time.deltaTime;

        switch (bossMovement)
        {
            case 1:
                step = speed_1 * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target_1.transform.position, step);
                break;
            case 2:         
                step = speed_2 * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target_2.transform.position, step);
                break;
            case 3:
                laugh.Play();
                step = speed_3 * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target_3.transform.position, step);
                break;
            case 4:
                step = speed_4 * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target_4.transform.position, step);
                break;
            case 5:
                step = speed_5 * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target_5.transform.position, step);
                break;
            case 6:
                step = speed_6 * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target_6.transform.position, step);
                break;


        }
    }

    public void BossRunAwaySequence()
    {
        ow.Play();
        Invoke("PoopMap", 1f);
        Invoke("RunAway1", 1.25f);
        Invoke("RunAway2", 2.5f);
    }

    private void RunAway1()
    {
        bossMovement = 5;
    }

    private void RunAway2()
    {
        bossMovement = 6;
    }

    private void PoopMap()
    {
        poopMap.SetActive(true);
        shit.Play();
    }
}
