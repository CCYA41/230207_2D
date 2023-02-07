using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [Header("Status")]
    public float vx;
    public float bulletSpeed;
    public float destroyTimer;


    public string curState;

    quaternion quat;
    Rigidbody2D rigi2D;
    Animator animator;

    private void Awake()
    {
        Initalize();
    }
    private void Initalize()
    {
        rigi2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        rigi2D.gravityScale = 0;

        rigi2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        vx = 0;
        bulletSpeed = 5f;

        curState = "Bullet";
    }


    private void Update()
    {
        Bullet();
    }
    private void Bullet()
    {
        if (destroyTimer > 1)
        {
            rigi2D.constraints = RigidbodyConstraints2D.None;
            Destroy(this.gameObject);
        }
        if (curState == "Boom")
        {
            destroyTimer += Time.deltaTime;

        }

        animator.Play(curState);

    }


    private void OnEnable()
    {

        vx = bulletSpeed;
        if (this.gameObject.activeSelf)
        {

            if (this.transform.rotation.z >= 0)
                rigi2D.AddForce(Vector2.left * vx, ForceMode2D.Impulse);
            else
                rigi2D.AddForce(Vector2.right * vx, ForceMode2D.Impulse);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        curState = "Boom";
        rigi2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    

}
