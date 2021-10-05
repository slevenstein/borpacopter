using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class owSound : MonoBehaviour
{
    public AudioClip ow;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Goo")
        {
            AudioSource.PlayClipAtPoint(ow, transform.position, 20f);
        }
    }
}