using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misions : MonoBehaviour
{
    //public MisionLocations[] misions;

    
    public float time;

    
    public float twoStarTime;
    public float treeStarTime;

    public int stars;

    private int whatMision;

    
    public bool StartTimer;

    public GameManger gm;
    public GameUiManger uim;

    private void Awake()
    {
        gm = GameManger.FindObjectOfType<GameManger>();
        uim = GameUiManger.FindObjectOfType<GameUiManger>();
    }
    private void Start()
    {
        StartMission();
    }

    public void StartMission()
    {
        StartTimer = true;
    }
    private void Update()
    {
       
        if(StartTimer == true)
        {
            time -= Time.deltaTime;
        }
        if(time <= 0)
        {
            Failed();
        }
    }
    public void Completed()
    {
        StartTimer = false;
        if(time > treeStarTime)
        {
            stars = 3;
            uim.ThreeStarUI();
           
        }
        else if(time > twoStarTime)
        {
            stars = 2;
            uim.TwoStarUI();
            
        }
        else
        {
            stars = 1;
            uim.OneStarUI();
           
        }
        uim.timeText.text = "Your time was: " + time.ToString("0") + " Seconds";
        gm.AddStars(stars);
        gm.MisionEnd();
    }

    
    public void Failed()
    {
        uim.FaildUI();
        uim.timeText.text = "You Faild";
        gm.MisionEnd();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Completed();
        }
    }


}
