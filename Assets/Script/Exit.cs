using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [Header("Status")]
    bool gameClear; 
    private void Start()
    {
        gameClear= false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && GameMnager.keyCount >= 3)
        {
            gameClear = true;
        }
    }
}
