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
        Discharge
    }
    
    public Trash trash;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (trash == Trash.GreenTrash)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.grb == Cards.Garbage.GreenTrash) // Check if the card can go to the green trash
            {
                Debug.Log("Green Trash touched !");
            } else
            {
                Debug.Log("Not the good Trash :'( !");
            }
        }
        if (trash == Trash.YellowTrash)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.grb == Cards.Garbage.YellowTrash) // Check if the card can go to the yellow trash
            {
                Debug.Log("Yellow Trash touched !");
            } else
            {
                Debug.Log("Not the good Trash :'( !");
            }
        }
        if (trash == Trash.Discharge)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.grb == Cards.Garbage.Discharge) // Check if the card can go to the Discharge trash
            {
                Debug.Log("Discharge Trash touched !");
            } else
            {
                Debug.Log("Not the good Trash :'( !");
            }
        }
        if (trash == Trash.OrdureMenagere)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.grb == Cards.Garbage.OrdureMenagere) // Check if the card can go to the OrdureMenagere trash
            {
                Debug.Log("OrdureMenagere Trash touched !");
            } else
            {
                Debug.Log("Not the good Trash :'( !");
            }
        }
        GameManager.Instance.InstantiateCard();
        other.gameObject.SetActive(false);
    }
}
