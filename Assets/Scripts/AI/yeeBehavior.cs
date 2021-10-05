using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeeBehavior : MonoBehaviour
{
    //public float damping;
    public float spin;
    //public float distance;
    //Vector3 wantedPosition;
    float counter;
    public float bulletLinger;
    private void Start()
    {
        counter = 0;
    }

    private void FixedUpdate()
    {
        counter += Time.deltaTime % 60;

        if (counter >= bulletLinger)
        {
            //Debug.Log("Destroyed");
            Destroy(gameObject);
        }

        //transform.position = Vector3.MoveTowards(transform.position, wantedPosition, (Time.deltaTime * damping));
        gameObject.transform.Rotate(0, 0, spin, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
