using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCtrl : MonoBehaviour
{

    public void StartButton()
    {
        //Debug.Log("��ŸƮ!");
        GameMnager.gamestate = GameMnager.GAMESTATE.PLAY;
    }
    public void ReplayButton()
    {
        GameMnager.gamestate = GameMnager.GAMESTATE.START;
    }

}
 