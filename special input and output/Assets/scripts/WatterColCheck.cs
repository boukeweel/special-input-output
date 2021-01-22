using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WatterColCheck : MonoBehaviour
{
    public GameManger gm;
    private void Awake()
    {
        gm = GameManger.FindObjectOfType<GameManger>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Water"))
        {
            gm.ReloadScene();
        }
        if (collision.collider.CompareTag("Car"))
        {
            gm.ReloadScene();
        }
    }
}
