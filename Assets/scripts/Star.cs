using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour 
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;
    private AudioSource audioSource;
    private Rigidbody2D rigidBody;
    private bool canMove;

	// Use this for initialization
	void Awake () 
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Start () 
    {
        canMove = false;
	}

    void Update()
    {
        Move();
    }

    void OnMouseDown()
    {
        
    }

    void Move()
    {
        if (canMove)
        {
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
            rigidBody.MovePosition(rigidBody.position + Vector2.up * moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Target")
        {
            canMove = false;
            transform.SetParent(target.gameObject.transform);
        }
        else if (target.tag == "Star" && target.tag == "Obstacle")
        {
            SceneManager.LoadScene("game_over"); 
        }
    }
}
