using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomTranslate : MonoBehaviour 
{
    [SerializeField] private float minXPosition, maxXPosition, minYPosition, maxYPosition, moveSpeed, invokeTime;
    Vector3 newPosition;

	// Use this for initialization
	void Start () 
    {
        newPosition = transform.localPosition;
        InvokeRepeating("ChangePosition", 0, invokeTime);
	}

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, newPosition, moveSpeed * Time.deltaTime);
    }

    void ChangePosition()
    {
        transform.localPosition = newPosition;
        newPosition = new Vector3(Random.Range(transform.localPosition.x + minXPosition, transform.localPosition.x + maxXPosition), Random.Range(transform.localPosition.y + minYPosition, transform.localPosition.y + maxYPosition), 0f);
    }
}
