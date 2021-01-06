using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelectionUI : MonoBehaviour
{

    public TMP_Text totalStars;

    private void Start()
    {
        totalStars.text = "Total Stars: " + HoldallStars.instance.totalStars.ToString();
    }

    public void SelectLevel(string WhatLevel)
    {
        SceneManager.LoadScene(WhatLevel);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
