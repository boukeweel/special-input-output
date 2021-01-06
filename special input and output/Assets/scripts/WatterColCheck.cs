using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WatterColCheck : MonoBehaviour
{
    private GameManger gm;
    private void Awake()
    {
        gm = GetComponent<GameManger>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Water"))
        {
            gm.ReloadScene();
        }
    }
}
