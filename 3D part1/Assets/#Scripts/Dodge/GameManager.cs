using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerController playerController;

    public BulletSpawner[] bulletSpawner;

    public float Checktime;
    public float time;

    [Header ("UI")]
    public TextMeshProUGUI UI_Hp;
    public TextMeshProUGUI UI_Time;
    public TextMeshProUGUI UI_GameOver;
    public TextMeshProUGUI UI_BestRecord;
    public int record;
    public int bestrecord;
    void Awake()
    {
        GameManager.instance = this;  //변수 초기화부 // 

    }
    void Start()
    {
        StartGame();
        bestrecord =  PlayerPrefs.GetInt("BestRecord", bestrecord);
    }



    // Update is called once per frame
    void Update()
    {       
        time = Time.time - Checktime;

        UI_Hp.text = "Hp : "+ playerController.maxhp;
        UI_BestRecord.text = "Best : " + bestrecord;

        if (playerController.isDie == false)
        {
            UI_Time.text = "Time : " + (int)time ;

            record = (int)time;        
        }
        if (playerController.isDie == true)
        {
            if(record>bestrecord )
            {
                bestrecord = record;
                PlayerPrefs.SetInt("BestRecord", bestrecord);
            }
        }


        if (Input.GetKeyDown(KeyCode.R) && playerController.isDie == true)
        {
            GameManager.instance.playerController.gameObject.SetActive(true);
            for (int i = 0; i < bulletSpawner.Length; i++)
            {
                playerController.Init();
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }



    }
    public void EndGame()
    {
        UI_GameOver.gameObject.SetActive(true);
        UI_GameOver.text = "Record : " + record + "\nRestart Press R";
        
    }

    public void StartGame()
    {
        UI_GameOver.gameObject.SetActive(false);
        bestrecord = PlayerPrefs.GetInt("BestRecord", bestrecord);
    }
    public void DoTimerOffset()

    {
        Checktime = Time.time;
    }
}
