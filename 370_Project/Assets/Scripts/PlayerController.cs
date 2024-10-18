using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Suazo, Angel]
 * Last Updated: [10/17/2024]
 * [Movement for player script]
 */

public class PlayerController : MonoBehaviour
{
    //This will determine how many lives the player has
    public int lives = 3;

    //location of where the player respawn to
    private Vector3 startPos;

    //side to side movement speed
    public float speed = 10f;

    //jump force added when the player presses space
    public float jumpForce = 8f;

    //players rigidbody
    private Rigidbody rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        //set the startPos
        startPos = transform.position;
        //Set the reference to the players attached rigidbody
        rigidBody = GetComponent<Rigidbody>();

    }


    // Update is called once per frame
    void Update()
    {
        Move();
        HandleJumping();
    }


    /// <summary>
    /// lose a live and move the player back to startPos
    /// </summary>
    private void Respawn()
    {
        lives--;
        //bring the player back to startPos
        transform.position = startPos;
        //check to see if player  has 0 lives
        if (lives == 0)
        {
            //NOTE: PUT GAME OVER SCENE HERE
            //SceneManager.LoadScene(1);
        }

    }

    private void Move()
    {
        //player moves forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        ////player moves left
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        //player moves backwards
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        //player moves right
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void HandleJumping()
    {
        //Handles jumping 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;

            //raycast to detect if we are grounded
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                Debug.Log("Touching the ground");
                //adds velocity to the player object causing the player to jump upwards
                rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Cant Jump, not touching the ground");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if we collide with an enemy trigger, respawn
        if (other.gameObject.tag == "Enemy")
        {
            Respawn();
        }

        //if we collide with a portal trigger, reset the start position
        //and teleport the player to the next area
        if (other.gameObject.tag == "Portal")
        {
            //reset the startPos to the spawnPoint location
            startPos = other.gameObject.GetComponent<Portal>().spawnPoint.transform.position;
            //teleport the player to the new startPos
            transform.position = startPos;
        }
    }
}
