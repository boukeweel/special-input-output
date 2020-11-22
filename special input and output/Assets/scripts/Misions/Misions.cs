using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misions : MonoBehaviour
{
    public MisionLocations[] misions;

    public Object spawnObject;
    public float time;
    public Vector3 spawnPos;
    public int coins;

    private int whatMision;

    public bool missionEnded;
    public bool StartTimer;


    private void Update()
    {
        if(missionEnded == true)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                StartNewMission();
                missionEnded = false;
            }
        } 
        if(StartTimer == true)
        {
            time -= Time.deltaTime;
        }
        if(time <= 0)
        {
            Faild();
        }
    }
    public void SelectMision()
    {
        whatMision = Random.Range(0, misions.Length - 1);
        spawnObject = misions[whatMision].spawnobj;
        time = misions[whatMision].time;
        spawnPos = misions[whatMision].location;
        coins = misions[whatMision].coins;
    }
    public void StartNewMission()
    {
        SelectMision();
        Instantiate(spawnObject, spawnPos, Quaternion.identity);
        StartTimer = true;
        
    }
    /// <summary>
    /// Failed your mission
    /// </summary>
    public void Faild()
    {
        Destroy(spawnObject);
        missionEnded = true;
        //mabye iets met reputatie maken
    }
    /// <summary>
    /// you completed your mission
    /// </summary>
    public void Completed()
    {
        //todo add coins
        //mabye iets met reputatie maken
        Destroy(spawnObject);
        missionEnded = true;
    }

}
