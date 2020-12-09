using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldallStars : MonoBehaviour
{
    [Header(" level 1 is 0 int he list so level 2 is 1 in the list ect")]
    public  int[] starsFromLvls;
    private  int holdStars;
    public  int totalStars;

    public static HoldallStars instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public  void GetTheNewStars()
    {
        for (int i = 0; i < starsFromLvls.Length; i++)
        {
            holdStars += starsFromLvls[i];
        }
        
    }
    private void Update()
    {
        totalStars = holdStars;
    }
}
