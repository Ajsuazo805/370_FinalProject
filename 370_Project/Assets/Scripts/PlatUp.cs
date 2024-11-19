using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatUp : MonoBehaviour
{
    //game objects to determine how far left/right platform goes 
    public GameObject bottomPoint;
    public GameObject topPoint;

    // boundary points for left and right 
    private Vector3 bottomPos;
    private Vector3 topPos;

    //how fast platform travels
    public float speed;

    //the direction it is going 
    public bool goingBottom;

    private Rigidbody playerRigidbody;

    private bool playerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        bottomPos = bottomPoint.transform.position;
        topPos = topPoint.transform.position;

        playerRigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    /// <summary>
    /// Make the platform move down and up
    /// </summary>
    private void Move()
    {
        if (goingBottom == true)
        {
            //once the platform reaches the bottomPos - goingBottom is false
            if (transform.position.y <= bottomPos.y)
            {
                goingBottom = false;
            }
            else
            {
                //translate the platform down by speed using Time.deltaTime
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
        else
        {
            //once the platform reaches the topPos - goingBottom is true
            if (transform.position.y >= topPos.y)
            {
                goingBottom = true;
            }
            else
            {
                //translate the platform up by speed using Time.deltaTime
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
        }
        if (playerOn)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        if (playerRigidbody!=null)
        {
            playerRigidbody.MovePosition(playerRigidbody.position + (transform.position - transform.position) * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = false;
        }
    }
}
