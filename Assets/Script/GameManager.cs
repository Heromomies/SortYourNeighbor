using System;
using System.Collections;
using System.Collections.Generic;
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
    
    public List<Cards> cardOnStart;
    [HideInInspector] public int nbrCard;
    public float time;
    private void Start()
    {
        RandomCard();
    }

    public void RandomCard()
    {
        nbrCard = Random.Range(0, cardOnStart.Count);
    }
}
