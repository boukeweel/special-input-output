using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUiManger : MonoBehaviour
{

    public GameObject carButtons;
    public GameObject threeStar;
    public GameObject twoStar;
    public GameObject oneStar;
    public GameObject Faild;

    public GameObject EndMenuUi;
    public TMP_Text timeText;

    
    private void Awake()
    {
        SetItAllToStartSetting();
    }
    #region For The stars
    private void SetItAllToStartSetting()
    {
        carButtons.SetActive(true);
        threeStar.SetActive(false);
        twoStar.SetActive(false);
        oneStar.SetActive(false); 
        Faild.SetActive(false);
        EndMenuUi.SetActive(false);
    }
    public void ThreeStarUI()
    {
        threeStar.SetActive(true);
        ActivateEndUi();
    }
    public void TwoStarUI()
    {
        twoStar.SetActive(true);
        ActivateEndUi();
    }
    public void OneStarUI()
    {
        oneStar.SetActive(true);
        ActivateEndUi();
    }
    public void FaildUI()
    {
        Faild.SetActive(true);
        ActivateEndUi();
    }
    #endregion
    public void ActivateEndUi()
    {
        Time.timeScale = 0;
        carButtons.SetActive(false);
        EndMenuUi.SetActive(true);
        
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Contineu()
    {
        SceneManager.LoadScene("LevelSelction");
    }
}
