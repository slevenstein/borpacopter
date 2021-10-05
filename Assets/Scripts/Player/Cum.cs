using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goo : MonoBehaviour
{
    public GameObject goo_spawn;
    public GameObject goo_prefab;
    public float m_Thrust = 30f;

    public bool facing_right = true;
    public float goo_cooldown = 0.25f;
    public float counter = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime % 60;
        if (Input.GetKey("space"))
        {
            if (counter >= goo_cooldown)
            {
                counter = 0;
                StartCoroutine(ShootGoo());
            }
        }
    }

    IEnumerator ShootGoo()
    {
        float time = 1f;

        if (facing_right)
        {
            GameObject goo = Instantiate(goo_prefab, goo_spawn.transform.position, Quaternion.identity);
            Rigidbody2D rb = goo.GetComponent<Rigidbody2D>();
            rb.AddForce((transform.right + (new Vector3(GetComponent<Rigidbody2D>().velocity.x / 10f, 0f, 0f))) * m_Thrust);
            yield return new WaitForSeconds(time);
            Destroy(goo);
        }
        else
        {
            Vector3 rot = new Vector3(0, 180, 0);
            GameObject goo = Instantiate(goo_prefab, goo_spawn.transform.position, Quaternion.Euler(rot));
            Rigidbody2D rb = goo.GetComponent<Rigidbody2D>();
            rb.AddForce(-(transform.right + (new Vector3(-GetComponent<Rigidbody2D>().velocity.x / 10f, 0f, 0f))) * m_Thrust);
            yield return new WaitForSeconds(time);
            Destroy(goo);
        }

    }
}
