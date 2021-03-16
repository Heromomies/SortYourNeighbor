using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI starsText;

    [Tooltip("Number of Levels in the game (add One more) ")] public int numberLevels;
    
    // Update is called once per frame
    void Update()
    {
        UpdateStarsUi();
    }

    void UpdateStarsUi()
    {
        int sum = 0;
        for (int i = 1; i < numberLevels; i++)
        {
            sum += PlayerPrefs.GetInt("Level" + i); // Add the level 1 stars number
            Debug.Log(sum);
        }

        starsText.text = sum + "/" + (numberLevels - 1) *3;
    }
}
