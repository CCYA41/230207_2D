using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMnager : MonoBehaviour
{
    public enum GAMESTATE
    {
        START = 0,
        PLAY,
        GAMEOVER,
        GAMECLEAR
    }

    public static int keyCount;
    public float monsterTimer;



    public GameObject Player;
    public GameObject Monster;
    public GameObject[] UIKeys;
    public GameObject[] keys;
    public GameObject GameStartTitle;
    public GameObject GameClearTitle;
    public GameObject GameOverTitle;
    public GameObject GameRestartTitle;


    [Header("Status")]
    public int score;

    int awakeWhileCounter;
    int updateWhileCounter;

    

    public static GAMESTATE gamestate;

    Image image;
    Color color;

    PlayerCtrl playertCtrl;
    MonsterCtrl monsterCtrl;

     
    private void Awake()
    {
        
        playertCtrl = FindObjectOfType<PlayerCtrl>();
        monsterCtrl = FindObjectOfType<MonsterCtrl>();

        Initialize();
        //for (int i = 0; i < UIKeys.Length; i++)
        //{
        //    images[i] = UIKeys[i].GetComponent<Image>();
        //    color = images[i].color;
        //    color.a = 0.5f;
        //    images[i].color = color;
        //}


        //monsterDead = false;

    }

    private void Initialize()
    {
        gamestate = GAMESTATE.START;



        playertCtrl.Initialize();
        monsterCtrl.Initialize();

        awakeWhileCounter = 0;
        keyCount = 0;
        score = 0;

        while (awakeWhileCounter < UIKeys.Length)
        {

            keys[awakeWhileCounter].SetActive(true);

            image = UIKeys[awakeWhileCounter].GetComponent<Image>();
            color = image.color;
            color.a = 0.5f;
            image.color = color;

            awakeWhileCounter++;

        }
    }


    private void Update()
    {
        StateControl();
        Managing();

        //if (keys[0].activeSelf == false)
        //{
        //    Debug.Log("알파 복구 작동테스트");
        //    image = UIKeys[].GetComponent<Image>();
        //    color = image.color;
        //    color.a = 1f;
        //    image.color = color;
        //}
        //if (keys[1].activeSelf == false)
        //{
        //    image = UIKeys[].GetComponent<Image>();
        //    color = image.color;
        //    color.a = 1f;
        //    image.color = color;
        //}
        //if (keys[2].activeSelf == false)
        //{
        //    image = UIKeys[].GetComponent<Image>();
        //    color = image.color;
        //    color.a = 1f;
        //    image.color = color;
        //}




    }
    private void Managing()
    {
        score = keyCount;

        if (keyCount < 4)
        {
            while (updateWhileCounter < keys.Length)
            {
                if (!keys[updateWhileCounter].activeSelf)
                {
                    image = UIKeys[updateWhileCounter].GetComponent<Image>();
                    color = image.color;
                    color.a = 1f;
                    image.color = color;

                }
                updateWhileCounter++;
            }
            updateWhileCounter = 0;
        }
        if (monsterCtrl.monsterDie)
        {
            monsterTimer += Time.deltaTime;
            if (monsterTimer > 3)
            {
                monsterCtrl.Initialize();
                monsterTimer = 0;
            }
        }
    }
    private void StateControl()
    {
        switch (gamestate)
        {
            case GAMESTATE.START:
                Initialize();
                Time.timeScale = 0;
                GameStartTitle.SetActive(true);
                GameRestartTitle.SetActive(false);
                GameClearTitle.SetActive(false);
                GameOverTitle.SetActive(false);
                break;
            case GAMESTATE.PLAY:

                Time.timeScale = 1;
                GameStartTitle.SetActive(false);
                GameClearTitle.SetActive(false);
                GameOverTitle.SetActive(false);
                GameRestartTitle.SetActive(false);
                break;
            case GAMESTATE.GAMEOVER:
                Time.timeScale = 0;
                GameStartTitle.SetActive(false);
                GameClearTitle.SetActive(false);
                GameOverTitle.SetActive(true);
                GameRestartTitle.SetActive(true);
                break;
            case GAMESTATE.GAMECLEAR:
                Time.timeScale = 0;
                GameStartTitle.SetActive(false);
                GameClearTitle.SetActive(true);
                GameOverTitle.SetActive(false);
                GameRestartTitle.SetActive(true);
                break;
            default:
                break;
        }

    }



}


