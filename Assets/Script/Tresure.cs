using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tresure : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            GameMnager.keyCount++;
            this.gameObject.SetActive(false);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //if(collision.collider.CompareTag("Player"))
        //{
        //    this.gameObject.SetActive(false);
        //}

    }
}
