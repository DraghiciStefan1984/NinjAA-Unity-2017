using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstaclesAsChildren : MonoBehaviour 
{
    [SerializeField] int numOfObjects;
    [SerializeField] GameObject obstacle;
    Vector3 center;
    float radius;

    void Awake()
    {
        Vector3 center = transform.position;
        radius = 1.5f;
    }

    void Start()
    {
        for (int i = 0; i < numOfObjects; i++)
        {
            Vector3 instancePosition = RandomCircle();
            GameObject obstacleInstance = Instantiate(obstacle, instancePosition, Quaternion.identity);
            obstacleInstance.transform.parent = transform;
        }
    }

    Vector3 RandomCircle()
    {
        float angle = Random.value * 360f;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad)/2;
        pos.y = center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad)/2;
        pos.z = center.z;
        return pos;
    }
}
