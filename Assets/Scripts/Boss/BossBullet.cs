using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BossBullet : MonoBehaviour
{
    //public float damping;
    //public float spin;
    //public float distance;
    //Vector3 wantedPosition;
    float counter;
    public float bulletLinger;
    public ContactPoint2D[] contacts = new ContactPoint2D[10];
    public TileBase normalTile;
    public TileBase normalTile_slop_positive_out;
    public TileBase normalTile_slop_positive_in;
    public TileBase normalTile_slop_negative_out;
    public TileBase normalTile_slop_negative_in;

    public int poopSize = 5;
    private void Start()
    {
        counter = 0;
    }

    private void FixedUpdate()
    {
        counter += Time.deltaTime % 60;

        if (counter >= bulletLinger)
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }

        //transform.position = Vector3.MoveTowards(transform.position, wantedPosition, (Time.deltaTime * damping));
        //gameObject.transform.Rotate(0, 0, spin, Space.Self);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "map")
        {

            Destroy(gameObject);


            int contactCount = collision.contactCount;
            if (contactCount > contacts.Length)
                contacts = new ContactPoint2D[contactCount];
            collision.GetContacts(contacts);

            UnityEngine.Vector3 hitPosition = UnityEngine.Vector3.zero;

            hitPosition.x = contacts[0].point.x;
            hitPosition.y = contacts[0].point.y - 0.05f;
            var map = collision.gameObject.GetComponent<Tilemap>();
            TileBase tile = map.GetTile(map.WorldToCell(hitPosition));
            //Vector3 tileWorldPos = map.CellToWorld(map.WorldToCell(hitPosition));
            Vector3Int tilePos = map.WorldToCell(hitPosition);

            List<Vector3Int> surroundingTiles = new List<Vector3Int>();

            for(int i = -poopSize; i < poopSize; i++)
            {
                for(int j = -poopSize; j < poopSize; j++)
                {
                    surroundingTiles.Add(new Vector3Int(tilePos.x + i, tilePos.y + j, 0));
                }
            }

            foreach(Vector3Int adjacent_tile in surroundingTiles)
            {
                if(map.GetTile(adjacent_tile)!= null)
                {
                    if (map.GetTile(adjacent_tile).name == "spritesheet_63")
                    {
                        map.SetTile(adjacent_tile, normalTile);
                    }
                    else if (map.GetTile(adjacent_tile).name == "spritesheet_96")
                    {
                        map.SetTile(adjacent_tile, normalTile_slop_positive_in);
                    }
                    else if (map.GetTile(adjacent_tile).name == "spritesheet_66")
                    {
                        map.SetTile(adjacent_tile, normalTile_slop_positive_out);
                    }
                    else if (map.GetTile(adjacent_tile).name == "spritesheet_97")
                    {
                        map.SetTile(adjacent_tile, normalTile_slop_negative_in);
                    }
                    else if (map.GetTile(adjacent_tile).name == "spritesheet_67")
                    {
                        map.SetTile(adjacent_tile, normalTile_slop_negative_out);
                    }
                }
            }

        }
    }
}
