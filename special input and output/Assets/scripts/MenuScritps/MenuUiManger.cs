using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUiManger : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controls;


    private void Start()
    {
        mainMenu.SetActive(true);
        controls.SetActive(false);
    }
    public void SartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Controls()
    {
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        controls.SetActive(false);
    }
    public void Shop()
    {
        //wat er moet gebeuren voor de shop te openen hier
    }
}
