using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnSoulsBehavior : MonoBehaviour
{
    public bool moveLeft;
    public float moveDistance;
    public float moveSpeed;

    Vector3 finalPos;
    // Start is called before the first frame update
    void Start()
    {
        int myLeft = 1;
        if (moveLeft)
        {
            myLeft = -1;
        }
        finalPos = new Vector3(transform.position.x + (moveDistance * myLeft), transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = moveSpeed * Time.deltaTime;
        if(transform.position == finalPos)
        {
            //Destroy(gameObject);
            moveLeft = !moveLeft;
            int myLeft = 1;
            if (moveLeft)
            {
                myLeft = -1;
            }
            finalPos = new Vector3(transform.position.x + (moveDistance * myLeft), transform.position.y, transform.position.z);
        }
        transform.position = Vector3.MoveTowards(transform.position ,finalPos, step);
    }
}
