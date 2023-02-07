using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Rigidbody2D rigi2D;

    private void Start()

    {
        rigi2D = GetComponent<Rigidbody2D>();
        rigi2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        rigi2D.gravityScale = 0f;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && GameMnager.keyCount >= 3)
        {
            GameMnager.gamestate = GameMnager.GAMESTATE.GAMECLEAR;
        }
    }
}
