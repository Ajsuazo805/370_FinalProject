using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFront : MonoBehaviour
{
    //game objects to determine how far back/front platform goes 
    public GameObject backPoint;
    public GameObject frontPoint;

    // boundary points for back and front 
    private Vector3 backPos;
    private Vector3 frontPos;

    //how fast platform travels
    public float speed;

    //the direction it is going 
    public bool goingBack;

    private Rigidbody playerRigidbody;

    private bool playerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        backPos = backPoint.transform.position;
        frontPos = frontPoint.transform.position;

        playerRigidbody = GameObject.FindWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    /// <summary>
    /// Make the platform move back and front
    /// </summary>
    private void Move()
    {
        if (goingBack == true)
        {
            //once the platform reaches the backPos - goingBack is false
            if (transform.position.z <= backPos.z)
            {
                goingBack = false;
            }
            else
            {
                //translate the platform back by speed using Time.deltaTime
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
        }
        else
        {
            //once the platform reaches the frontPos - goingBack is true
            if (transform.position.z >= frontPos.z)
            {
                goingBack = true;
            }
            else
            {
                //translate the platform forward by speed using Time.deltaTime
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
        }
        if (playerOn)
        {
            MovePlayer();
        }
    }
    private void MovePlayer()
    {
        if (playerRigidbody != null)
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
