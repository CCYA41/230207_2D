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
    public float bulletTimer;
    public float destroyTimer;

    public GameObject bullet;

    public string curState;

    [SerializeField] bool leftFlag;
    [SerializeField] bool groundFlag;
    [SerializeField] bool jumpFlag;
    [SerializeField] bool playerDead; 

    Animator animator;
    Rigidbody2D rigi2D;
    SpriteRenderer sprite;
    CapsuleCollider2D capColl2D;

    Vector3 startPos;
    private void Start()
    {

        animator = GetComponent<Animator>();
        rigi2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        capColl2D = GetComponent<CapsuleCollider2D>();
    }

    public void Initialize()
    {
        vx = 0;
        vy = 0;
        runSpeed = 4;
        jumpSpeed = 9;
        bulletTimer = 0f;
        destroyTimer = 0f;

        leftFlag = false;
        jumpFlag = false;
        groundFlag = false;
        playerDead = false;

        curState = "Idle";


        startPos = new Vector3(-6f, -1.5f, 0);
        this.transform.position = startPos;

        rigi2D.velocity = new Vector2(0, 0);
        rigi2D.constraints = RigidbodyConstraints2D.None;
        rigi2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        capColl2D.enabled = true;

        this.gameObject.SetActive(true);
    }

    private void Update()
    {
        Player();
    }
    private void Player()
    {
        sprite.flipX = leftFlag;

        if (curState == "Boom")
        {
            destroyTimer += Time.deltaTime;

            if (destroyTimer > 2)
            {

                this.transform.position = startPos;
                GameMnager.gamestate = GameMnager.GAMESTATE.GAMEOVER;
                this.gameObject.SetActive(false);

            }
        }

        if (Input.GetKey("left") && groundFlag && !jumpFlag && rigi2D.velocity.y >= 0)
        {
            leftFlag = true;
            if (!jumpFlag)
            {
                vx = -runSpeed;
                //rigi2D.AddForce(new Vector2(-runSpeed, 0),ForceMode2D.Impulse);
                rigi2D.velocity = new Vector2(vx, 0);
            }
        }
        if (Input.GetKey("right") && groundFlag && !jumpFlag && rigi2D.velocity.y >= 0)
        {

            leftFlag = false;
            if (!jumpFlag)
            {
                vx = runSpeed;
                //rigi2D.AddForce(new Vector2(runSpeed, 0),ForceMode2D.Impulse);
                rigi2D.velocity = new Vector2(runSpeed, 0);
            }

        }
        if (Input.GetKey("space") && groundFlag && !jumpFlag)
        {
            jumpFlag = true;
            vx = rigi2D.velocity.x;
            vy = jumpSpeed;
            //rigi2D.AddForce(new Vector2(vx, jumpSpeed), ForceMode2D.Impulse);
            rigi2D.velocity = new Vector2(vx, vy);
        }


        bulletTimer += Time.deltaTime;
        if (Input.GetKey("a") && bulletTimer > 1)
        {
            bulletTimer = 0;

            if (leftFlag)
            {
                bullet.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, 0);
                bullet.transform.rotation = Quaternion.Euler(0, 0, 90);



            }
            else
            {
                bullet.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, 0);
                bullet.transform.rotation = Quaternion.Euler(0, 0, -90);



            }
            Instantiate(bullet);
        }
        animator.Play(curState);
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Monster"))
        {
            playerDead = true;
            curState = "Boom";

            capColl2D.enabled = false;

            rigi2D.constraints = RigidbodyConstraints2D.FreezeAll;

        }
        if (collision.collider.CompareTag("Enviroment"))
        {
            groundFlag = true;
            jumpFlag = false;

        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enviroment"))
        {
            groundFlag = true;
            jumpFlag = false;

        }


    }

}
