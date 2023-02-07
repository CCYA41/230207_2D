using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;

    [Header("Status")]
    [SerializeField] float vx;
    [SerializeField] float vy;

    void Update()
    {
        Camera();
    }
    private void Camera()
    {
        if (Player.activeSelf)
        {
            vx = Player.transform.position.x;
            vy = Player.transform.position.y;
            this.transform.position = new Vector3(vx, vy, -10);
        }
    }
}
