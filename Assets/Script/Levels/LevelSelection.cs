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
      UpdateLevelStatus();
      if (Input.GetKey(KeyCode.K))
      {
         PlayerPrefs.DeleteKey("Level");
         PlayerPrefs.DeleteAll();
      }
   }
   
   private void UpdateLevelStatus()
   {
      //If the current lvl is 5, the pre should be 4
      int previousLevelNum = int.Parse(gameObject.name) - 1;
      if (PlayerPrefs.GetInt("Level" + previousLevelNum) > 0)// If the first level star is bigger than 0
      {
         unlocked = true;
      }
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
