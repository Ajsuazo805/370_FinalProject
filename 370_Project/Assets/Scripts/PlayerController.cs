using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    
    public float speed = 5f;
    public float jumpForce = 8f;

    private bool isGrounded;

    private PlayerHealth playerHealth; 


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }


    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Move the player Forward");
            //W key to go FORWARD
            transform.position += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Move the player Left");
            //the A key goes LEFT
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Move the player Back");
            //the S key goes BACK
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Move the player Right");
            //D key to go RIGHT
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }

    private void Jump()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.5f))
        {
            if (hit.collider.tag == "Floor")
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
                Debug.Log(" not on ground");
            }
        }
        else
        {
            isGrounded = true;
            Debug.Log("on the ground");
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    public void TakeDamage(int damage)
    {
        playerHealth.TakeDamage(damage);
    }

}
