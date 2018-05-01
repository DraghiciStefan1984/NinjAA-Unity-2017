using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotateChange : MonoBehaviour 
{	
    [SerializeField] float minRotationSpeed, maxRotationSpeed;
    private float rotateSpeed;
    private Vector3 pointA;
    private Vector3 pointB;

    public void Start()
    {
        rotateSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        pointA = transform.eulerAngles + new Vector3(0f, 0f, 240f);
        pointB = transform.eulerAngles + new Vector3(0f, 0f, -240f);
    }

    public void Update()
    {
        Rotate(); 
    }

    void Rotate()
    {
        float time = Mathf.PingPong(Time.time * rotateSpeed, 1);
        transform.eulerAngles = Vector3.Lerp(pointA, pointB, time);
    }
}
