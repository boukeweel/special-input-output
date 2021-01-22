using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_controller : MonoBehaviour
{

    public Rigidbody sph_Rig;
    public SphereCollider sph_col;

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

    [HideInInspector]public bool gasHold;
    [HideInInspector] public bool breakHold;
    [HideInInspector] public float addgas;

    [HideInInspector] public bool ableToMove;

    private bool released = false;


    // Start is called before the first frame update
    void Start()
    {
        sph_Rig.transform.parent = null;
        ableToMove = true;
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
        if (ableToMove == true)
        {


            if (gasHold && released == false)
            {
                speedInput = addgas * forwardSpeed * 1000f;
                if (forwardSpeed < maxSpeed)
                {
                    forwardSpeed += 0.01f;
                }
            }
            else if (breakHold)
            {
                speedInput = addgas * backwardSpeed * 1000f;
                forwardSpeed = 1;
            }


            //I am using this as tilt controls because my phone does not support cyroscoop so this was the selution
            turnInput = Input.acceleration.x;
            //turnInput = Input.GetAxis("Horizontal");



            if (grounded)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * addgas, 0f));
            }

            //wheel rotation
            LeftWheel.localRotation = Quaternion.Euler(LeftWheel.localRotation.eulerAngles.x, (turnInput * maxwheelturn) - 180, LeftWheel.localRotation.eulerAngles.z);
            rightwheel.localRotation = Quaternion.Euler(rightwheel.localRotation.eulerAngles.x, (turnInput * maxwheelturn), rightwheel.localRotation.eulerAngles.z);

            //follow the shpere
            transform.position = sph_Rig.transform.position;

            //slow down the car but it still needs to roll for a time
            SlowDown();
        }
    }

    private void FixedUpdate()
    {


        CheckIfGrounded();
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
    //check if the car is grounded
    private void CheckIfGrounded()
    {
        grounded = false;
        RaycastHit hit;
        //check if the car is on the ground

        if (Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
    }

    //slow the car down in a slow manner
    public void SlowDown()
    {
        if(released == true)
        {
            speedInput = addgas * forwardSpeed * 1000f;
            if (forwardSpeed > 0)
            {

                forwardSpeed -= 0.01f;
            }
            if (forwardSpeed <= 0)
            {
                forwardSpeed = 0;
                addgas = 0;
                gasHold = false;
                released = false;
            }
        }
        
        
    }

    //give gas when you press the button
    public void GiveGas()
    {
        gasHold = true;
        addgas = 1;
        released = false;
    }
    //whe 
    public void ReleasGas()
    {
        
        released = true;
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
