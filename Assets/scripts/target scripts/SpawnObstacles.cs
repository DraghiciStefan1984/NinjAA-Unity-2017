using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour 
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject obstacle;
    [SerializeField] int numOfObstacles;

	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < numOfObstacles; i++)
        {
            int rand = Random.Range(0, spawnPoints.Length);
            if (rand < spawnPoints.Length)
            {
                GameObject obstacleInstance = Instantiate(obstacle, spawnPoints[rand].transform.position, Quaternion.identity);
                obstacleInstance.transform.parent = transform;
            }
        }
	}
}
