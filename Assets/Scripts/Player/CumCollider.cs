using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GooCollider : MonoBehaviour
{

    public ContactPoint2D[] contacts = new ContactPoint2D[10];
    public TileBase gooTile;
    public TileBase gooTile_slop_positive_out;
    public TileBase gooTile_slop_positive_in;
    public TileBase gooTile_slop_negative_out;
    public TileBase gooTile_slop_negative_in;

    public int gooSize = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "map")
        {
            Destroy(gameObject);

            int contactCount = col.contactCount;
            if (contactCount > contacts.Length)
                contacts = new ContactPoint2D[contactCount];
            col.GetContacts(contacts);



            UnityEngine.Vector3 hitPosition = UnityEngine.Vector3.zero;
            // for (int i = 0; i != contactCount; ++i)

            //{

            hitPosition.x = contacts[0].point.x;
            hitPosition.y = contacts[0].point.y - 0.05f;
            var map = col.gameObject.GetComponent<Tilemap>();
            TileBase tile = map.GetTile(map.WorldToCell(hitPosition));
            //Vector3 tileWorldPos = map.CellToWorld(map.WorldToCell(hitPosition));
            Vector3Int tilePos = map.WorldToCell(hitPosition);


            List<Vector3Int> surroundingTiles = new List<Vector3Int>();

            for (int i = -gooSize; i < gooSize; i++)
            {
                for (int j = -gooSize; j < gooSize; j++)
                {
                    surroundingTiles.Add(new Vector3Int(tilePos.x + i, tilePos.y + j, 0));
                }
            }

            foreach (Vector3Int adjacent_tile in surroundingTiles)
            {
                if (map.GetTile(adjacent_tile) != null)
                {
                    if (map.GetTile(adjacent_tile).name == "spritesheet_243")
                    {
                        map.SetTile(adjacent_tile, gooTile);
                    }
                    else if (map.GetTile(adjacent_tile).name == "spritesheet_276")
                    {
                        map.SetTile(adjacent_tile, gooTile_slop_positive_in);
                    }
                    else if (map.GetTile(adjacent_tile).name == "spritesheet_246")
                    {
                        map.SetTile(adjacent_tile, gooTile_slop_positive_out);
                    }
                    else if (map.GetTile(adjacent_tile).name == "spritesheet_277")
                    {
                        map.SetTile(adjacent_tile, gooTile_slop_negative_in);
                    }
                    else if (map.GetTile(adjacent_tile).name == "spritesheet_247")
                    {
                        map.SetTile(adjacent_tile, gooTile_slop_negative_out);
                    }
                }
            }
            /*
            if (map.GetTile(tilePos).name == "spritesheet_243" || map.GetTile(tilePos).name == "spritesheet_63")
            {
                Vector3Int left_1 = new Vector3Int(tilePos.x - 1, tilePos.y, tilePos.z);

                Vector3Int left_2 = new Vector3Int(tilePos.x - 2, tilePos.y, tilePos.z);

                Vector3Int left_3 = new Vector3Int(tilePos.x - 3, tilePos.y, tilePos.z);

                Vector3Int left_4 = new Vector3Int(tilePos.x - 4, tilePos.y, tilePos.z);

                Vector3Int right_1 = new Vector3Int(tilePos.x + 1, tilePos.y, tilePos.z);

                Vector3Int right_2 = new Vector3Int(tilePos.x + 2, tilePos.y, tilePos.z);

                Vector3Int right_3 = new Vector3Int(tilePos.x + 3, tilePos.y, tilePos.z);

                Vector3Int right_4 = new Vector3Int(tilePos.x + 4, tilePos.y, tilePos.z);


                if (map.GetTile(tilePos).name == "spritesheet_243")
                    map.SetTile(tilePos, gooTile);

                if (map.GetTile(left_1).name == "spritesheet_243")
                    map.SetTile(left_1, gooTile);

                if (map.GetTile(left_2).name == "spritesheet_243")
                    map.SetTile(left_2, gooTile);

                if (map.GetTile(left_3).name == "spritesheet_243")
                    map.SetTile(left_3, gooTile);

                if (map.GetTile(left_4).name == "spritesheet_243")
                    map.SetTile(left_4, gooTile);

                if (map.GetTile(right_1).name == "spritesheet_243")
                    map.SetTile(right_1, gooTile);

                if (map.GetTile(right_2).name == "spritesheet_243")
                    map.SetTile(right_2, gooTile);

                if (map.GetTile(right_3).name == "spritesheet_243")
                    map.SetTile(right_3, gooTile);

                if (map.GetTile(right_4).name == "spritesheet_243")
                    map.SetTile(right_4, gooTile);
            }
            else if(map.GetTile(tilePos).name == "spritesheet_276" || map.GetTile(tilePos).name == "spritesheet_96")
            {           

                Vector3Int left_1 = new Vector3Int(tilePos.x - 1, tilePos.y, tilePos.z);

                Vector3Int left_2 = new Vector3Int(tilePos.x - 1, tilePos.y - 1, tilePos.z);

                Vector3Int left_3 = new Vector3Int(tilePos.x - 2, tilePos.y - 1, tilePos.z);

                Vector3Int left_4 = new Vector3Int(tilePos.x - 2, tilePos.y - 2, tilePos.z);

                Vector3Int left_5 = new Vector3Int(tilePos.x - 3, tilePos.y - 2, tilePos.z);

                Vector3Int right_1 = new Vector3Int(tilePos.x, tilePos.y + 1, tilePos.z);

                Vector3Int right_2 = new Vector3Int(tilePos.x + 1, tilePos.y + 1, tilePos.z);

                Vector3Int right_3 = new Vector3Int(tilePos.x + 1, tilePos.y + 2, tilePos.z);

                Vector3Int right_4 = new Vector3Int(tilePos.x + 2, tilePos.y + 2, tilePos.z);

                Vector3Int right_5 = new Vector3Int(tilePos.x + 2, tilePos.y + 3, tilePos.z);

                if (map.GetTile(tilePos).name == "spritesheet_276")
                {
                    map.SetTile(tilePos, gooTile_slop_positive_in);
                }

                if (map.GetTile(left_1).name == "spritesheet_246" || map.GetTile(left_1).name == "spritesheet_276")
                {
                    if (map.GetTile(left_1).name == "spritesheet_246")
                    {
                        map.SetTile(left_1, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(left_1, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(left_2).name == "spritesheet_246" || map.GetTile(left_2).name == "spritesheet_276")
                {
                    if (map.GetTile(left_2).name == "spritesheet_246")
                    {
                        map.SetTile(left_2, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(left_2, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(left_3).name == "spritesheet_246" || map.GetTile(left_3).name == "spritesheet_276")
                {
                    if (map.GetTile(left_3).name == "spritesheet_246")
                    {
                        map.SetTile(left_3, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(left_3, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(left_4).name == "spritesheet_246" || map.GetTile(left_4).name == "spritesheet_276")
                {
                    if (map.GetTile(left_4).name == "spritesheet_246")
                    {
                        map.SetTile(left_4, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(left_4, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(left_5).name == "spritesheet_246" || map.GetTile(left_5).name == "spritesheet_276")
                {
                    if (map.GetTile(left_5).name == "spritesheet_246")
                    {
                        map.SetTile(left_5, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(left_5, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(right_1).name == "spritesheet_246" || map.GetTile(right_1).name == "spritesheet_276")
                {
                    if (map.GetTile(right_1).name == "spritesheet_246")
                    {
                        map.SetTile(right_1, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(right_1, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(right_2).name == "spritesheet_246" || map.GetTile(right_2).name == "spritesheet_276")
                {
                    if (map.GetTile(right_2).name == "spritesheet_246")
                    {
                        map.SetTile(right_2, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(right_2, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(right_3).name == "spritesheet_246" || map.GetTile(right_3).name == "spritesheet_276")
                {
                    if (map.GetTile(right_3).name == "spritesheet_246")
                    {
                        map.SetTile(right_3, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(right_3, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(right_4).name == "spritesheet_246" || map.GetTile(right_4).name == "spritesheet_276")
                {
                    if (map.GetTile(right_4).name == "spritesheet_246")
                    {
                        map.SetTile(right_4, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(right_4, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(right_5).name == "spritesheet_246" || map.GetTile(right_5).name == "spritesheet_276")
                {
                    if (map.GetTile(right_5).name == "spritesheet_246")
                    {
                        map.SetTile(right_5, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(right_5, gooTile_slop_positive_in);

                    }
                }
            }
            else if (map.GetTile(tilePos).name == "spritesheet_246" || map.GetTile(tilePos).name == "spritesheet_66")
            {

                Vector3Int left_1 = new Vector3Int(tilePos.x, tilePos.y - 1, tilePos.z);

                Vector3Int left_2 = new Vector3Int(tilePos.x - 1, tilePos.y - 1, tilePos.z);

                Vector3Int left_3 = new Vector3Int(tilePos.x - 1, tilePos.y - 2, tilePos.z);

                Vector3Int left_4 = new Vector3Int(tilePos.x - 2, tilePos.y - 2, tilePos.z);

                Vector3Int left_5 = new Vector3Int(tilePos.x - 2, tilePos.y - 3, tilePos.z);

                Vector3Int right_1 = new Vector3Int(tilePos.x + 1, tilePos.y, tilePos.z);

                Vector3Int right_2 = new Vector3Int(tilePos.x + 1, tilePos.y + 1, tilePos.z);

                Vector3Int right_3 = new Vector3Int(tilePos.x + 2, tilePos.y + 1, tilePos.z);

                Vector3Int right_4 = new Vector3Int(tilePos.x + 2, tilePos.y + 2, tilePos.z);

                Vector3Int right_5 = new Vector3Int(tilePos.x + 3, tilePos.y + 2, tilePos.z);

                if (map.GetTile(tilePos).name == "spritesheet_246")
                {
                    map.SetTile(tilePos, gooTile_slop_positive_out);
                }

                if (map.GetTile(left_1).name == "spritesheet_246" || map.GetTile(left_1).name == "spritesheet_276")
                {
                    if (map.GetTile(left_1).name == "spritesheet_246")
                    {
                        map.SetTile(left_1, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(left_1, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(left_2).name == "spritesheet_246" || map.GetTile(left_2).name == "spritesheet_276")
                {
                    if (map.GetTile(left_2).name == "spritesheet_246")
                    {
                        map.SetTile(left_2, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(left_2, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(left_3).name == "spritesheet_246" || map.GetTile(left_3).name == "spritesheet_276")
                {
                    if (map.GetTile(left_3).name == "spritesheet_246")
                    {
                        map.SetTile(left_3, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(left_3, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(left_4).name == "spritesheet_246" || map.GetTile(left_4).name == "spritesheet_276")
                {
                    if (map.GetTile(left_4).name == "spritesheet_246")
                    {
                        map.SetTile(left_4, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(left_4, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(left_5).name == "spritesheet_246" || map.GetTile(left_5).name == "spritesheet_276")
                {
                    if (map.GetTile(left_5).name == "spritesheet_246")
                    {
                        map.SetTile(left_5, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(left_5, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(right_1).name == "spritesheet_246" || map.GetTile(right_1).name == "spritesheet_276")
                {
                    if (map.GetTile(right_1).name == "spritesheet_246")
                    {
                        map.SetTile(right_1, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(right_1, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(right_2).name == "spritesheet_246" || map.GetTile(right_2).name == "spritesheet_276")
                {
                    if (map.GetTile(right_2).name == "spritesheet_246")
                    {
                        map.SetTile(right_2, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(right_2, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(right_3).name == "spritesheet_246" || map.GetTile(right_3).name == "spritesheet_276")
                {
                    if (map.GetTile(right_3).name == "spritesheet_246")
                    {
                        map.SetTile(right_3, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(right_3, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(right_4).name == "spritesheet_246" || map.GetTile(right_4).name == "spritesheet_276")
                {
                    if (map.GetTile(right_4).name == "spritesheet_246")
                    {
                        map.SetTile(right_4, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(right_4, gooTile_slop_positive_in);

                    }
                }

                if (map.GetTile(right_5).name == "spritesheet_246" || map.GetTile(right_5).name == "spritesheet_276")
                {
                    if (map.GetTile(right_5).name == "spritesheet_246")
                    {
                        map.SetTile(right_5, gooTile_slop_positive_out);
                    }
                    else
                    {
                        map.SetTile(right_5, gooTile_slop_positive_in);

                    }
                }
            }
            else if (map.GetTile(tilePos).name == "spritesheet_277" || map.GetTile(tilePos).name == "spritesheet_97")
            {

                Vector3Int left_1 = new Vector3Int(tilePos.x, tilePos.y + 1, tilePos.z);

                Vector3Int left_2 = new Vector3Int(tilePos.x - 1, tilePos.y + 1, tilePos.z);

                Vector3Int left_3 = new Vector3Int(tilePos.x - 1, tilePos.y + 2, tilePos.z);

                Vector3Int left_4 = new Vector3Int(tilePos.x - 2, tilePos.y + 2, tilePos.z);

                Vector3Int left_5 = new Vector3Int(tilePos.x - 2, tilePos.y + 3, tilePos.z);

                Vector3Int right_1 = new Vector3Int(tilePos.x + 1, tilePos.y, tilePos.z);

                Vector3Int right_2 = new Vector3Int(tilePos.x + 1, tilePos.y - 1, tilePos.z);

                Vector3Int right_3 = new Vector3Int(tilePos.x + 2, tilePos.y - 1, tilePos.z);

                Vector3Int right_4 = new Vector3Int(tilePos.x + 2, tilePos.y - 2, tilePos.z);

                Vector3Int right_5 = new Vector3Int(tilePos.x + 3, tilePos.y - 2, tilePos.z);

                if (map.GetTile(tilePos).name == "spritesheet_277")
                {
                    map.SetTile(tilePos, gooTile_slop_negative_in);
                }

                if (map.GetTile(left_1).name == "spritesheet_277" || map.GetTile(left_1).name == "spritesheet_247")
                {
                    if (map.GetTile(left_1).name == "spritesheet_247")
                    {
                        map.SetTile(left_1, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(left_1, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(left_2).name == "spritesheet_277" || map.GetTile(left_2).name == "spritesheet_247")
                {
                    if (map.GetTile(left_2).name == "spritesheet_247")
                    {
                        map.SetTile(left_2, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(left_2, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(left_3).name == "spritesheet_277" || map.GetTile(left_3).name == "spritesheet_247")
                {
                    if (map.GetTile(left_3).name == "spritesheet_247")
                    {
                        map.SetTile(left_3, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(left_3, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(left_4).name == "spritesheet_277" || map.GetTile(left_4).name == "spritesheet_247")
                {
                    if (map.GetTile(left_4).name == "spritesheet_247")
                    {
                        map.SetTile(left_4, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(left_4, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(left_5).name == "spritesheet_277" || map.GetTile(left_5).name == "spritesheet_247")
                {
                    if (map.GetTile(left_5).name == "spritesheet_247")
                    {
                        map.SetTile(left_5, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(left_5, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(right_1).name == "spritesheet_277" || map.GetTile(right_1).name == "spritesheet_247")
                {
                    if (map.GetTile(right_1).name == "spritesheet_247")
                    {
                        map.SetTile(right_1, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(right_1, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(right_2).name == "spritesheet_277" || map.GetTile(right_2).name == "spritesheet_247")
                {
                    if (map.GetTile(right_2).name == "spritesheet_247")
                    {
                        map.SetTile(right_2, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(right_2, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(right_3).name == "spritesheet_277" || map.GetTile(right_3).name == "spritesheet_247")
                {
                    if (map.GetTile(right_3).name == "spritesheet_247")
                    {
                        map.SetTile(right_3, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(right_3, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(right_4).name == "spritesheet_277" || map.GetTile(right_4).name == "spritesheet_247")
                {
                    if (map.GetTile(right_4).name == "spritesheet_247")
                    {
                        map.SetTile(right_4, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(right_4, gooTile_slop_negative_in);

                    }

                    if (map.GetTile(right_5).name == "spritesheet_277" || map.GetTile(right_5).name == "spritesheet_247")
                    {
                        if (map.GetTile(right_5).name == "spritesheet_247")
                        {
                            map.SetTile(right_5, gooTile_slop_negative_out);
                        }
                        else
                        {
                            map.SetTile(right_5, gooTile_slop_negative_in);

                        }
                    }
                }
            }
            else if (map.GetTile(tilePos).name == "spritesheet_247" || map.GetTile(tilePos).name == "spritesheet_67")
            {

                Vector3Int left_1 = new Vector3Int(tilePos.x - 1, tilePos.y, tilePos.z);

                Vector3Int left_2 = new Vector3Int(tilePos.x - 1, tilePos.y + 1, tilePos.z);

                Vector3Int left_3 = new Vector3Int(tilePos.x - 2, tilePos.y + 1, tilePos.z);

                Vector3Int left_4 = new Vector3Int(tilePos.x - 2, tilePos.y + 2, tilePos.z);

                Vector3Int left_5 = new Vector3Int(tilePos.x - 3, tilePos.y + 2, tilePos.z);

                Vector3Int right_1 = new Vector3Int(tilePos.x, tilePos.y - 1, tilePos.z);

                Vector3Int right_2 = new Vector3Int(tilePos.x + 1, tilePos.y - 1, tilePos.z);

                Vector3Int right_3 = new Vector3Int(tilePos.x + 1, tilePos.y - 2, tilePos.z);

                Vector3Int right_4 = new Vector3Int(tilePos.x + 2, tilePos.y - 2, tilePos.z);

                Vector3Int right_5 = new Vector3Int(tilePos.x + 2, tilePos.y - 3, tilePos.z);

                if (map.GetTile(tilePos).name == "spritesheet_247")
                {
                    map.SetTile(tilePos, gooTile_slop_negative_out);
                }

                if (map.GetTile(left_1).name == "spritesheet_277" || map.GetTile(left_1).name == "spritesheet_247")
                {
                    if (map.GetTile(left_1).name == "spritesheet_247")
                    {
                        map.SetTile(left_1, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(left_1, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(left_2).name == "spritesheet_277" || map.GetTile(left_2).name == "spritesheet_247")
                {
                    if (map.GetTile(left_2).name == "spritesheet_247")
                    {
                        map.SetTile(left_2, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(left_2, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(left_3).name == "spritesheet_277" || map.GetTile(left_3).name == "spritesheet_247")
                {
                    if (map.GetTile(left_3).name == "spritesheet_247")
                    {
                        map.SetTile(left_3, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(left_3, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(left_4).name == "spritesheet_277" || map.GetTile(left_4).name == "spritesheet_247")
                {
                    if (map.GetTile(left_4).name == "spritesheet_247")
                    {
                        map.SetTile(left_4, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(left_4, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(left_5).name == "spritesheet_277" || map.GetTile(left_5).name == "spritesheet_247")
                {
                    if (map.GetTile(left_5).name == "spritesheet_247")
                    {
                        map.SetTile(left_5, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(left_5, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(right_1).name == "spritesheet_277" || map.GetTile(right_1).name == "spritesheet_247")
                {
                    if (map.GetTile(right_1).name == "spritesheet_247")
                    {
                        map.SetTile(right_1, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(right_1, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(right_2).name == "spritesheet_277" || map.GetTile(right_2).name == "spritesheet_247")
                {
                    if (map.GetTile(right_2).name == "spritesheet_247")
                    {
                        map.SetTile(right_2, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(right_2, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(right_3).name == "spritesheet_277" || map.GetTile(right_3).name == "spritesheet_247")
                {
                    if (map.GetTile(right_3).name == "spritesheet_247")
                    {
                        map.SetTile(right_3, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(right_3, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(right_4).name == "spritesheet_277" || map.GetTile(right_4).name == "spritesheet_247")
                {
                    if (map.GetTile(right_4).name == "spritesheet_247")
                    {
                        map.SetTile(right_4, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(right_4, gooTile_slop_negative_in);

                    }
                }

                if (map.GetTile(right_5).name == "spritesheet_277" || map.GetTile(right_5).name == "spritesheet_247")
                {
                    if (map.GetTile(right_5).name == "spritesheet_247")
                    {
                        map.SetTile(right_5, gooTile_slop_negative_out);
                    }
                    else
                    {
                        map.SetTile(right_5, gooTile_slop_negative_in);

                    }
                }
            }
            */
        }
        else if(col.gameObject.tag == "boss")
        {
            Destroy(gameObject);
            BossBehavior bb = col.gameObject.GetComponent<BossBehavior>();
            bb.health--;
            if (bb.health == 0)
            {
                bb.BossRunAwaySequence();
            }
        }
    }
}
