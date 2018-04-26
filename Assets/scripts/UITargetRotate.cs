using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITargetRotate : MonoBehaviour 
{
    [SerializeField] private float rotateSpeed;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
	}
}
