using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCard : MonoBehaviour
{
    public Cards card;
    public float fMovingSpeed;

    private int _numberCard;
    private bool _isMouseOver;
    private void Start()
    {
        GameManager.Instance.RandomCard();
        _numberCard = GameManager.Instance.nbrCard;
        card = GameManager.Instance.cardOnStart[_numberCard];
       
        GameManager.Instance.cardOnStart.Remove(GameManager.Instance.cardOnStart[_numberCard]);
        
        Debug.Log(_numberCard);
        Debug.Log(card.rel);
    }
    void Update()
    {
        //Movement
        if (Input.GetMouseButton(0) && _isMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), fMovingSpeed);
        }
        //Checking the speed
        //Right Side
        if (transform.position.x > 1)
        {
            if (!Input.GetMouseButton(0))
            {
                Debug.Log("Right !");
            }
        }
        //Left Side
        else if (transform.position.x < -1)
        {
            
            if (!Input.GetMouseButton(0))
            {
                Debug.Log("Left !");
            }
        }
    }

    private void OnMouseOver()
    {
        _isMouseOver = true;
    }

    private void OnMouseExit()
    {
        _isMouseOver = false;
    }
}
