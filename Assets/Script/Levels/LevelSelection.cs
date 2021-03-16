using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
   [SerializeField] private bool unlocked;
   public Image unlockImage;
   public GameObject[] stars;

   private void Update()
   {
      UpdateLevelImage();
   }

   private void UpdateLevelImage()
   {
      if (!unlocked)
      {
         unlockImage.gameObject.SetActive(true);
         gameObject.GetComponent<Button>().interactable = false;
         for (int i = 0; i < stars.Length; i++)
         {
            stars[i].gameObject.SetActive(false);
         }
      }
      else
      {
         unlockImage.gameObject.SetActive(false);
         gameObject.GetComponent<Button>().interactable = true;
         for (int i = 0; i < stars.Length; i++)
         {
            stars[i].gameObject.SetActive(true);
         }
      }
   }

   public void PressSelection(string nameScene) // When we press this level, we can move to the corresponding Scene
   {
      if (unlocked)
      {
         SceneManager.LoadScene(nameScene);
      }
   }
}
