using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Transform Camera;

    public float dist;
    public float height;
    public float smoothRotate;


   

    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Debug.DrawRay(target.position, target.forward, Color.red);
        float lerpAngle = Mathf.LerpAngle(Camera.eulerAngles.y, target.eulerAngles.y, smoothRotate * Time.deltaTime);
        Quaternion rot = Quaternion.Euler(0, lerpAngle, 0);
        Camera.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);
        Camera.LookAt(target);
        
    }
}
