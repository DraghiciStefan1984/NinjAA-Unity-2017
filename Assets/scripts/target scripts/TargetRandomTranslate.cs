using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomTranslate : MonoBehaviour 
{
    [SerializeField] private float minXPosition, maxXPosition, minYPosition, maxYPosition, moveSpeed, invokeTime;
    Vector3 newPosition;

	// Use this for initialization
	void Start () 
    {
        newPosition = new Vector3(0f, 2f, 0f);
        InvokeRepeating("ChangePosition", 0, invokeTime);
	}

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }

    void ChangePosition()
    {
        transform.position = newPosition;
        newPosition = new Vector3(Random.Range(minXPosition, maxXPosition), Random.Range(minYPosition, maxYPosition), 0f);
    }
}
