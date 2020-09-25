using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_controller : MonoBehaviour
{

    public Rigidbody sph_Rig;

    public float forwardSpeed = 8f;
    public float backwardSpeed = 4f;
    public float maxSpeed = 50f;
    public float turnStrength = 180f;

    private float speedInput;
    private float turnInput;


    // Start is called before the first frame update
    void Start()
    {
        sph_Rig.transform.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        if(Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardSpeed * 1000f;
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * backwardSpeed * 1000f;
        }

        turnInput = Input.GetAxis("Horizontal");

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));



        transform.position = sph_Rig.transform.position;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(speedInput)> 0)
        {
            sph_Rig.AddForce(transform.forward * speedInput);
        }
    }
}
