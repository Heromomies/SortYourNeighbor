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

        gameObject.GetComponent<SpriteRenderer>().color = card.color;
    }
    void Update()
    {
        //Movement
        if (Input.GetMouseButton(0) && _isMouseOver) // Can move the card with the mouse
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), fMovingSpeed);
        }
    }

    #region MouseOver
    private void OnMouseOver() { _isMouseOver = true; }
    private void OnMouseExit() { _isMouseOver = false; }
    #endregion
}
