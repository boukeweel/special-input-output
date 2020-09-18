using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testen : MonoBehaviour
{
    public float speed;

    bool holdbutton = false;

    Rigidbody rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody>()
    }
    private void Update()
    {
        if(holdbutton)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public void test()
    {
        holdbutton = true;
        Debug.Log("werkt?");
    }
}
