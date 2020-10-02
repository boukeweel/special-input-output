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


    // Start is called before the first frame update
    void Start()
    {
        sph_Rig.transform.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        //turn
        if(Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardSpeed * 1000f;
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * backwardSpeed * 1000f;
        }

        turnInput = Input.GetAxis("Horizontal");

        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        }
        

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
}
