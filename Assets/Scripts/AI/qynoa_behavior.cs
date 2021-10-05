using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qynoa_behavior : MonoBehaviour
{
    public bool faceRight;

    BoxCollider2D myHitbox;
    float counter;

    float curHeight;

    // Start is called before the first frame update
    void Start()
    {
        myHitbox = gameObject.GetComponent<BoxCollider2D>();
        if (!faceRight)
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Hit box under will be really bad but just don't use it there
        //change size of hitbox to match animation
        //offset -.56
        //top most height to 1.7

        counter += Time.deltaTime % 60;
        //Debug.Log(counter);
        //myHitbox.size.y
        // .25 == 4
        //.5 == 8
        //counter = 1 == 1.6

        // 1.25 = 8
        // 1.5 = 4
        if (counter <= 1)
        {
            //Debug.Log(counter * 1.6);
            myHitbox.size = new Vector2(myHitbox.size.x, (float)(counter * 1.6));
        }
        else if(counter <= 2)
        {
            //Debug.Log((float)((counter -1) * -1.6 + 1.6 ));
            myHitbox.size = new Vector2(myHitbox.size.x, (float)((counter - 1) * -1.6 + 1.6));
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
