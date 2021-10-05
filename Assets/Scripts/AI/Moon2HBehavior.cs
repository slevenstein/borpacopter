using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon2HBehavior : MonoBehaviour
{
    public GameObject yeeBullet;
    public GameObject spawnPos;
    public float spawnTimer;

    public bool lookAtPlayer;

    GameObject player;

    //public float yeeDamping;
    public float yeeSpin;
    //public float yeeDistance;
    public float yeeSpeed;
    public float bulletLinger;
    float counter;
    // Update is called once per frame

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
                var offset = 180f;
                Vector2 direction = (Vector2)player.transform.position - (Vector2)transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
            }

            counter += Time.deltaTime % 60;

            if (counter >= spawnTimer)
            {
                GameObject yee = Instantiate(yeeBullet, spawnPos.transform.position, spawnPos.transform.rotation);
                yee.GetComponent<yeeBehavior>().spin = yeeSpin;
                Rigidbody2D rb = yee.GetComponent<Rigidbody2D>();
                rb.AddForce(spawnPos.transform.right * -yeeSpeed, ForceMode2D.Impulse);
                yee.GetComponent<yeeBehavior>().bulletLinger = bulletLinger;
                counter = 0;
            }
        }
    }
}
