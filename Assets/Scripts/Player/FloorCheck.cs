using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class FloorCheck : MonoBehaviour
{
    public ContactPoint2D[] contacts = new ContactPoint2D[10];
    public PlayerMovement pm;

    public float normalSpeedCap;
    public float gooSpeedCap;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.name == "map")
        {

            int contactCount = col.contactCount;
            if (contactCount > contacts.Length)
                contacts = new ContactPoint2D[contactCount];
            col.GetContacts(contacts);

            UnityEngine.Vector3 hitPosition = UnityEngine.Vector3.zero;

            hitPosition.x = contacts[0].point.x;
            hitPosition.y = contacts[0].point.y - 0.05f;

            string name = col.gameObject.GetComponent<Tilemap>().GetTile(col.gameObject.GetComponent<Tilemap>().WorldToCell(hitPosition)).name;

            //print(name);



            if (name == "spritesheet_63" || name == "spritesheet_66" || name == "spritesheet_96" || name == "spritesheet_67" || name == "spritesheet_97") // goo tiles
            {
                if(pm.runSpeed >= gooSpeedCap)
                {
                    pm.runSpeed = gooSpeedCap;
                }
                else
                {
                    pm.runSpeed *= 1.03f;
                }
            }
            else if (name == "spritesheet_243" || name == "spritesheet_246" || name == "spritesheet_276" || name == "spritesheet_247" || name == "spritesheet_277") // normal tiles
            {
                
                if (pm.runSpeed <= normalSpeedCap)
                {
                    pm.runSpeed = normalSpeedCap;
                }
                else
                {
                    pm.runSpeed /= 1.06f;
                }
            }


        }
    }
}
