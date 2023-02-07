using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TresureUI : MonoBehaviour
{

    Image image;
    Color color;


    private void Awake()
    {
        Initailize();
    }
    private void Initailize()
    {
        // 프로퍼티라 이렇게 받아와야 하는거같음 
        image = GetComponent<Image>();
        color = image.color;
        color.a = 0.5f;
        image.color = color;
    }
}
