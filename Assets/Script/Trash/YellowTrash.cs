using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowTrash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<TakeCard>().card.rel == Cards.Religion.YellowTrash) // Check if the card can go to the yellow trash
        {
            Debug.Log("Yellow Trash touched !");
        }
        else
        {
            Debug.Log("Not the good Trash :'(  !");
        }
    }
}
