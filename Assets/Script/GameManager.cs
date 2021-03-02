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
    public GameObject cardToInstantiate;
    
    [HideInInspector] public int nbrCard;
    public float time;

    private int _objectInList;
    private void Start()
    {
        RandomCard();
        _objectInList = cardOnStart.Count;
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
        //TODO Level finish 
    }
}
