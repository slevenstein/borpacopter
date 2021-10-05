using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2 : MonoBehaviour
{
    public Transform player;
    public int timeToMove;
    public float endX;
    public bool isRight = true;
    public int bossHealth = 3;
    public AudioClip laugh;
    public AudioClip ow;

    float startX;
    bool bossMoving = false;
    float step;
    bool immune = false;

    float counter = 0f;
    public float bulletLinger = 2f;
    public float avgSpawnRate = 2f;
    public GameObject poop_prefab;
    public GameObject spawnPos;
    public AudioClip fart;

    private float spawnTimer;

    public GameObject[] shooters;

    GameObject GameManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 3 * avgSpawnRate;

        startX = transform.position.x;

        step = (endX - transform.position.x) / timeToMove;

        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += Time.deltaTime % 60;

        if (bossHealth < 3 && counter >= spawnTimer)
        {
            ShootPoop();
            counter = 0;
        }

        if (bossMoving) {
            float newX = transform.position.x + step;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            if ((isRight && newX < endX) || (!isRight && newX > startX)) {
                bossMoving = false;
                isRight = !isRight;
                step *= -1;

                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;

                immune = false;
            }
        }
        else if ((isRight && player.position.x > startX) || (!isRight && player.position.x < endX)) {
            bossMoving = true;
            AudioSource.PlayClipAtPoint(laugh, transform.position, 20f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Goo")) {
            

            Destroy(other.gameObject);
            if (!immune) {
                --bossHealth;
                
                spawnTimer -= avgSpawnRate;
            
                if (bossHealth < 3) {
                    shooters[0].SetActive(true);
                    shooters[1].SetActive(true);
                }
                if (bossHealth < 2) {
                    shooters[2].SetActive(true);
                    shooters[3].SetActive(true);
                }

                AudioSource.PlayClipAtPoint(ow, transform.position, 20f);
                immune = true;
            }
            if (bossHealth < 1) {
                GameManager.GetComponent<GameManagement>().GameWon();
            }
        }
    }

    void ShootPoop()
    {
        float bullet_speed = Random.Range(-30f, 30f);
        GameObject poop = Instantiate(poop_prefab, spawnPos.transform.position, spawnPos.transform.rotation);
        Rigidbody2D rb = poop.GetComponent<Rigidbody2D>();
        rb.AddForce(spawnPos.transform.right * bullet_speed, ForceMode2D.Impulse);
        poop.GetComponent<BossBullet>().bulletLinger = bulletLinger;
        AudioSource.PlayClipAtPoint(fart, transform.position, 20f);
    }
}
