using System.Collections;
using System.Collections.Generic;
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

    public Trash trash;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (trash == Trash.GreenTrash)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.rel == Cards.Religion.GreenTrash) // Check if the card can go to the green trash
            {
                Debug.Log("Green Trash touched !");
            }
            else
            {
                Debug.Log("Not the good Trash :'( !");
                
            }
        }
        if (trash == Trash.YellowTrash)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.rel == Cards.Religion.YellowTrash) // Check if the card can go to the yellow trash
            {
                Debug.Log("Yellow Trash touched !");
            }
            else
            {
                Debug.Log("Not the good Trash :'( !");
            }
        }
        if (trash == Trash.Discharge)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.rel == Cards.Religion.Discharge) // Check if the card can go to the Discharge trash
            {
                Debug.Log("Discharge Trash touched !");
            }
            else
            {
                Debug.Log("Not the good Trash :'( !");
            }
        }
        if (trash == Trash.OrdureMenagere)
        {
            if (other.gameObject.GetComponent<TakeCard>().card.rel == Cards.Religion.OrdureMenagere) // Check if the card can go to the OrdureMenagere trash
            {
                Debug.Log("OrdureMenagere Trash touched !");
            }
            else
            {
                Debug.Log("Not the good Trash :'( !");
            }
        }
        GameManager.Instance.InstantiateCard();
        other.gameObject.SetActive(false);
    }
}
