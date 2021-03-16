using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    public enum Trash
    {
        GreenTrash,
        YellowTrash,
        OrdureMenagere,
        Discharge,
        None
    }
    public TextMeshProUGUI scoreTxt;
    private int _score;
    public Trash trash;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (trash == Trash.GreenTrash)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.grb == Cards.Garbage.GreenTrash) // Check if the card can go to the green trash
            {
                _score =_score += 10;
                scoreTxt.text = $"Score : {_score}";
                Debug.Log("Green Trash touched !");
            }
        }
        if (trash == Trash.YellowTrash)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.grb == Cards.Garbage.YellowTrash) // Check if the card can go to the yellow trash
            {
                _score = _score += 10;
                scoreTxt.text = $"Score : {_score}";
                Debug.Log("Yellow Trash touched !");
            }
        }
        if (trash == Trash.Discharge)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.grb == Cards.Garbage.Discharge) // Check if the card can go to the Discharge trash
            {
                _score = _score += 10;
                scoreTxt.text = $"Score : {_score}";
                Debug.Log("Discharge Trash touched !");
            }
        }
        if (trash == Trash.OrdureMenagere)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.grb == Cards.Garbage.OrdureMenagere) // Check if the card can go to the OrdureMenagere trash
            {
                _score = _score + 10;
                scoreTxt.text = $"Score : {_score}";
                Debug.Log("OrdureMenagere Trash touched !");
            }
        }
        else
        {
            _score -= 10;
            Debug.Log("Not the good Trash :'( !");
            scoreTxt.text = $"Score : {_score}";
        }
        GameManager.Instance.InstantiateCard();
        other.gameObject.SetActive(false);
    }
}
