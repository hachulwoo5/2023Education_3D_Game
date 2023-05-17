using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball_GameManager : MonoBehaviour
{
    public static Ball_GameManager instance;
    public Ball_BallCont ballCont;
    public Ball_Floor floor;

    [Header("Obj")]
    public GameObject Ball;
    public GameObject Map;
    Vector3 InitPos; 

    public float Checktime;
    public float time;

    [Header("UI")]
    public TextMeshProUGUI UI_Time;
    public TextMeshProUGUI UI_GameOver;
    public TextMeshProUGUI UI_BestRecord;

    public bool isGoal;
    public int record;
    public float bestrecord;
    void Awake()
    {
     
        Ball_GameManager.instance = this;  //변수 초기화부 // 
        InitPos = Ball.transform.position; 


    }
    void Start()
    {
        Init();
        bestrecord = PlayerPrefs.GetFloat("BestRecord_Ball", bestrecord);
    }



    // Update is called once per frame
    void Update()
    {
        time = Time.time - Checktime;

        
        UI_BestRecord.text = "Best : " + bestrecord;
        

        if (!isGoal)
        {
            UI_Time.text = "Time : " + (int)time;
            record = (int)time;
        }
        else if (isGoal)
        {
            EndGame();
            if ( bestrecord ==0 )
            {
                bestrecord = record;
                PlayerPrefs.SetFloat("BestRecord_Ball", bestrecord);
            }
            else if (bestrecord != 0 && record < bestrecord)
            {
                bestrecord = record;
                PlayerPrefs.SetFloat("BestRecord_Ball", bestrecord);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Init();
            }
        }


       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.DeleteAll();
        }

    }
    public void EndGame()
    {
        UI_GameOver.gameObject.SetActive(true);
        UI_GameOver.text = "Record : " + record + "\nRestart Press R";

    }

    public void Init()
    {
        isGoal = false;
        UI_GameOver.gameObject.SetActive(false);
        bestrecord = PlayerPrefs.GetFloat("BestRecord_Ball", bestrecord);
        Checktime = Time.time;

        Ball.transform.position = InitPos;
        Map.transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    
}
