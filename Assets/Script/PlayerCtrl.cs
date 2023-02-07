using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Header("Status")]
    public float vx;
    public float vy;
    public float runSpeed;
    public float jumpSpeed;

    [SerializeField] bool leftFlag;
    [SerializeField] bool groundFlag;
    [SerializeField] bool jumpFlag;

    Rigidbody2D rigi2D;
    SpriteRenderer sprite;
    private void Awake()
    {
        vx = 0;
        vy = 0;
        runSpeed = 4;
        jumpSpeed = 7;

        leftFlag = false;
        jumpFlag = false;
        groundFlag = false;

        rigi2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        rigi2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        if (Input.GetKey("left") && !jumpFlag)
        {
            sprite.flipX = !leftFlag;
            if (!jumpFlag)
             //rigi2D.AddForce(new Vector2(-runSpeed, 0),ForceMode2D.Impulse);
                rigi2D.velocity = new Vector2(-runSpeed, 0);
            else
                rigi2D.velocity = new Vector2(-runSpeed / 2, 0);

        }
        if (Input.GetKey("right")&&!jumpFlag)
        {
            sprite.flipX = leftFlag;
            if (!jumpFlag)
                //rigi2D.AddForce(new Vector2(runSpeed, 0),ForceMode2D.Impulse);
                rigi2D.velocity = new Vector2(runSpeed, 0);
            else
                rigi2D.velocity = new Vector2(runSpeed / 2, 0);
        }
        if (Input.GetKey("space") && groundFlag && !jumpFlag)
        {
            jumpFlag = true;
            rigi2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enviroment"))
        {
            if (jumpFlag)
            {
                groundFlag = true;
                jumpFlag = false;
            }
            else
                groundFlag = true;

        }

    }
}
