using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mission Locations", menuName = "Location")]
public class MisionLocations : ScriptableObject
{
    [Header("voor de normaal Ground is it 0.6 for 1 up is .............")]
    public Vector3 location = new Vector3(0, 0.6f, 0);
    public GameObject spawnobj;
    public float time;
    public int coins;
}
