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


    public float gravaityForce = 10f;
    public bool grounded;

    public LayerMask whatIsGround;
    public float groundRayLength = 0.5f;

    public Transform groundRayPoint;


    public float r_drag = 3f;

    public Transform LeftWheel;
    public Transform rightwheel;

    public float maxwheelturn;

    public bool gasHold;
    public bool breakHold;
    public float addgas;



    // Start is called before the first frame update
    void Start()
    {
        sph_Rig.transform.parent = null;

        //if (SystemInfo.supportsGyroscope)
        //{
        //    Debug.Log("yeet");
        //    Input.gyro.enabled = true;
        //}
        
    }

    private Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(0, q.z, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        //turn
        /*Input.GetAxis("Vertical") > 0*/
        if (gasHold)
        {
            speedInput = addgas * forwardSpeed * 1000f;
            if(forwardSpeed < maxSpeed)
            {
                forwardSpeed += 0.01f;
            }
        }
        else if (breakHold)
        {
            speedInput = addgas * backwardSpeed * 1000f;
            forwardSpeed = 1;
        }



        turnInput = Input.acceleration.x;
        //turnInput = Input.GetAxis("Horizontal");



        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * addgas, 0f));
        }

        //wheel rotation
        LeftWheel.localRotation = Quaternion.Euler(LeftWheel.localRotation.eulerAngles.x, (turnInput * maxwheelturn) - 180, LeftWheel.localRotation.eulerAngles.z);
        rightwheel.localRotation = Quaternion.Euler(rightwheel.localRotation.eulerAngles.x, (turnInput * maxwheelturn) , rightwheel.localRotation.eulerAngles.z);

        //follow the shpere
        transform.position = sph_Rig.transform.position;
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;
        //check if the car is on the ground

        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }


        if (grounded)
        {
            sph_Rig.drag = r_drag;
            if (Mathf.Abs(speedInput) > 0)
            {
                sph_Rig.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            sph_Rig.drag = 0.1f;
            sph_Rig.AddForce(Vector3.up * -gravaityForce * 100f);
        }
    }

    //give gas when you press the button
    public void GiveGas()
    {
        gasHold = true;
        addgas = 1;
    }
    //whe 
    public void ReleasGas()
    {
        gasHold = false;
        addgas = 0;
    }

    public void HoldBreak()
    {
        breakHold = true;
        addgas = -1;
    }
    public void ReleaseBreak()
    {
        breakHold = false;
        addgas = 0;
    }
}
