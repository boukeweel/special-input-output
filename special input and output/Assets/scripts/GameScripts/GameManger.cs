using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public Car_controller Car;

    public int starsInThisLvl;

    public int whatLevel;

    private void Awake()
    {
        Car = Car_controller.FindObjectOfType<Car_controller>();
    }
    public void AddStars(int addStars)
    {
        starsInThisLvl += addStars;
    }

    public void MisionEnd()
    {
        Car.ableToMove = false;
        Debug.Log("ja hier komt die");

        if (starsInThisLvl > HoldallStars.instance.starsFromLvls[whatLevel])
        {
            
            HoldallStars.instance.starsFromLvls[whatLevel] = starsInThisLvl;
            HoldallStars.instance.GetTheNewStars();
        }

    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
