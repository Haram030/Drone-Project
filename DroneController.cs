using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    public Transform cameraTransform;
    Vector3 moveDirection;

    // Move Inputs
    float accelValue;
    float brakeValue;
    float sideValue;
    float upValue;
    
    float rollValue;
    float pitchValue;
    float yawValue;

    
    public float accelAmount;
    public float brakeAmount;
    float rotateLerpAmount;
    Vector3 rotateValue;
    Vector3 moveVec;

    public float maxSpeed = 301.7f;
    public float speed;
    public float minSpeed = 15f;
    public float defaultSpeed = 60;
    public float calibrateAmount;


    public float rollAmount;
    public float pitchAmount;
    public float yawAmount;


    Rigidbody rb;

    float speedReciprocal;


    //Moblie Key Var
    bool up_Down;
    bool down_Down;
    bool left_Down;
    bool right_Down;
    bool leftR_Down;
    bool rightR_Down;
    bool Accel_Down;
    bool Brake_Down;
    bool up_Up;
    bool down_Up;
    bool left_Up;
    bool leftR_Up;
    bool right_Up;
    bool rightR_Up;
    bool Accel_Up;
    bool Brake_Up;





    void MoveDrone()
    {
        //Rotation

        rotateValue = new Vector3(pitchValue * pitchAmount, yawValue * yawAmount, rollValue * rollAmount);

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotateValue * Time.fixedDeltaTime));

        //Move

        moveDirection = cameraTransform.TransformDirection(moveDirection);

        if (Accel_Down == true || Brake_Down == true)
        {
            moveVec = new Vector3(0, 0, accelValue);

        }
        else if (left_Down == true || right_Down == true)
        {
            moveVec = new Vector3(sideValue, 0, 0);

        }
        else if (up_Down == true || down_Down == true)
        {
            moveVec = new Vector3(0, upValue, 0);

        }
        else if (Accel_Up == true || Brake_Up == true)
        {
            moveVec = new Vector3(0, 0, accelValue);
        }
        else if (left_Up == true || right_Up == true)
        {
            moveVec = new Vector3(sideValue, 0, 0);

        }
        else if (up_Up == true || down_Up == true)
        {
            moveVec = new Vector3(0, upValue, 0);

        }
        


        rb.velocity = moveVec * speed * Time.fixedDeltaTime;

        up_Down = false;
        down_Down = false;
        left_Down = false;
        right_Down = false;
        leftR_Down = false;
        rightR_Down = false;
        Accel_Down = false;
        Brake_Down = false;
        up_Up = false;
        down_Up = false;
        left_Up = false;
        leftR_Up = false;
        right_Up = false;
        rightR_Up = false;
        Accel_Up = false;
        Brake_Up = false;

    }

    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "A":
                accelValue = -1;
                Accel_Down = true;
                
                break;
            case "B":
                accelValue = 1;
                Brake_Down = true;
               
                break;
            case "LR":
                rollValue = -1;
                leftR_Down = true;
                break;
            case "RR":
                rollValue = 1;
                rightR_Down = true;
                break;
            case "L":
                sideValue = 1;
                left_Down = true;
               
                break;
            case "R":
                sideValue = -1;
                left_Down = true;
                
                break;
            case "U":
                upValue = 1;
                up_Down = true;

                break;
            case "D":
                upValue = -1;
                down_Down = true;

                break;

        }
    }

    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "A":
                accelValue = 0;
                Accel_Up = true;
                
                break;
            case "B":
                accelValue = 0;
                Brake_Up = true;
                
                break;
            case "LR":
                rollValue = 0;
                leftR_Up = true;
                break;
            case "RR":
                rollValue = 0;
                leftR_Up = true;
                break;
            case "L":
                sideValue = 0;
                left_Up = true;
               
                break;
            case "R":
                sideValue = 0;
                right_Up = true;
               
                break;
            case "U":
                upValue = 0;
                up_Up = true;

                break;
            case "D":
                upValue = 0;
                down_Up = true;

                break;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        MoveDrone();
    }

    // Update is called once per frame
    void Update()
    { 

    }
}
