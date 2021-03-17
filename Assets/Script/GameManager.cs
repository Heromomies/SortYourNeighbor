using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            { 
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    #endregion
    
    [Header("Cards")]
    public List<Cards> cardOnStart;
    public GameObject cardToInstantiate;

    [HideInInspector] public int nbrCard;
    public TextMeshProUGUI garbageText;
    
    
    [Header("Timer")]
    public float timeRemaining = 10;
    public bool timerIsRunning;
    public TextMeshProUGUI timeText;
    
    
    [Header("Level Manager")]
    public int levelIndex;
    public int timeForOneStar, timeForTwoStars, timeForThreeStars;

    private int _currentStarsNum;
    private int _objectInList;
    private void Start()
    {
        RandomCard();
        _objectInList = cardOnStart.Count;
        timerIsRunning = true;
        PlayerPrefs.DeleteAll();
    }

    public void RandomCard()
    {
        nbrCard = Random.Range(0, cardOnStart.Count);
    }
    public void InstantiateCard()
    {
        Instantiate(cardToInstantiate, transform.position, Quaternion.identity);
        _objectInList--;
        
        if (_objectInList <= 0)
        {
            Debug.Log("There is no card in the list");
            LevelFinish();   
        }
    }

    public void LevelFinish()
    {
        timerIsRunning = false;
        if (timeRemaining >= timeForThreeStars)
        {
            NumberStars(3);
        }
        else if (timeRemaining >= timeForTwoStars)
        {
            NumberStars(2);
        }
        else if (timeRemaining >= timeForOneStar)
        {
            NumberStars(1);
        }
       
        //TODO Level finish 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            LevelFinish();
        }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    public void NumberStars(int starNum)
    {
        _currentStarsNum = starNum;
        if (_currentStarsNum > PlayerPrefs.GetInt("Level" + levelIndex))
        {
            PlayerPrefs.SetInt("Level" + levelIndex, starNum);
        }
        Debug.Log(PlayerPrefs.GetInt("Level" + levelIndex, starNum));
    }
    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
