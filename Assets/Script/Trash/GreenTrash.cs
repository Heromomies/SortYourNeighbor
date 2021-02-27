using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTrash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<TakeCard>().card.rel == Cards.Religion.GreenTrash) // Check if the card can go to the green trash
        {
            Debug.Log("Green Trash touched !");
        }
        else
        {
            Debug.Log("Not the good Trash :'(  !");
        }
    }
}
