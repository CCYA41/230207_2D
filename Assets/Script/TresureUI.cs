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
        // ������Ƽ�� �̷��� �޾ƿ;� �ϴ°Ű��� 
        image = GetComponent<Image>();
        color = image.color;
        color.a = 0.5f;
        image.color = color;
    }
}
