using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float moveSpeed;

    Vector3 startPos;
    Vector3 endPos;
    Vector3 moveToPos;
    public bool left;

    public float moveDis;

    public Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        moveToPos = new Vector3(startPos.x - moveDis, startPos.y, startPos.z);
        endPos = moveToPos;
        left = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        var curPos = transform.position;
        if (curPos == lastPos)
        {
            left = !left;
            if (left)
            {
                moveToPos = endPos;
            }
            else
            {
                moveToPos = startPos;
            }

            Flip();
        }
        lastPos = curPos;
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector2.Lerp(transform.position, moveToPos, step);
    }

    private void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
