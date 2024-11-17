using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatSide : MonoBehaviour
{
    //game objects to determine how far left/right platform goes 
    public GameObject leftPoint;
    public GameObject rightPoint;

    // boundary points for left and right 
    private Vector3 leftPos;
    private Vector3 rightPos;

    //how fast platform travels
    public float speed;

    //the direction it is going 
    public bool goingLeft;

    // Start is called before the first frame update
    void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    /// <summary>
    /// Make the platform move left and right
    /// </summary>
    private void Move()
    {
        if (goingLeft == true)
        {
            //once the platform reaches the leftPos - goingLeft is false
            if (transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                //translate the platform left by speed using Time.deltaTime
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            //once the platform reaches the rightPos - goingLeft is true
            if (transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                //translate the platform right by speed using Time.deltaTime
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}
