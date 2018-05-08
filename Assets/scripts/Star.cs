using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Star : MonoBehaviour 
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private AudioClip hitSound;

    private Rigidbody2D targetBody;
    private CircleCollider2D targetCollider;

    private AudioSource audioSource;
    private bool canMove;

	// Use this for initialization
	void Awake () 
    {
        targetBody = GameObject.FindGameObjectWithTag("Target").GetComponent<Rigidbody2D>();
        targetCollider = GameObject.FindGameObjectWithTag("Target").GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Start () 
    {
        canMove = true;
	}

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (canMove)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        audioSource.PlayOneShot(hitSound);
        if (target.tag == "Target")
        {
            canMove = false;
            transform.SetParent(target.gameObject.transform);
        }

        if (target.tag == "Star" || target.tag == "Obstacle")
        {
            StartCoroutine(LoadLoseScreen());
        }
    }

    IEnumerator LoadLoseScreen()
    {
        
        targetBody.isKinematic = false;
        targetCollider.enabled = false;
        StarSpawner.CanSpawn = false;
        this.GetComponent<Rigidbody2D>().isKinematic = false;
        this.GetComponent<PolygonCollider2D>().enabled = false;
        canMove = false;

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("game_over"); 
    }
}
