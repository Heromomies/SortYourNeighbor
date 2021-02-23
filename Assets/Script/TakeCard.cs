using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCard : MonoBehaviour
{
    public Cards card;

    private int _numberCard;
    private void Start()
    {
        GameManager.Instance.RandomCard();
        _numberCard = GameManager.Instance.nbrCard;
        card = GameManager.Instance.cardOnStart[_numberCard];
       
        GameManager.Instance.cardOnStart.Remove(GameManager.Instance.cardOnStart[_numberCard]);
        
        Debug.Log(_numberCard);
        Debug.Log(card.rel);
    }
}
