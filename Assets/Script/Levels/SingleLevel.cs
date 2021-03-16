using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{
   private int _currentStarsNum;
   public int levelIndex;

   public void BackButton()
   {
      SceneManager.LoadScene("LevelSelector");
   }
   public void PressStarsButton(int starNum)
   {
      _currentStarsNum = starNum;
      if (_currentStarsNum > PlayerPrefs.GetInt("Level" + levelIndex))
      {
         PlayerPrefs.SetInt("Level" + levelIndex, starNum);
      }
      Debug.Log(PlayerPrefs.GetInt("Level" + levelIndex, starNum));
   }
}
