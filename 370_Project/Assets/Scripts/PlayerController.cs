using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: [Suazo, Angel; Gibson, Hannah ; Arteaga, Yasmine]
 * Last Updated: [10/17/2024]
 * [Movement for player script]
 */

public class PlayerController : MonoBehaviour
{
    // mouse sensitivity
    public float mouseSen = 100f;


    public float xRotate = 0f;

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

    PlayerHealth playerHealth;

    public Transform cameraTransform;

    public GameObject laserPrefab;

    public int manaAmount = 1;

    public int damage = 1;

    public int currentLives ;

    public Transform respawnPoint;

    public Transform Player;

    private float lastSpawner = 0f;
    private float spawnDelay = 3f;

    public int playerEchoes;

    public int playerMana;


    public GameObject manaPrefab;

    public GameObject Plat1;

    private bool manaPrefabInstantiated = false;

    //WILL USE NEXT SPRINT
    //public float teleportDistance = 2f;
    //public bool canTeleport = true;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //current health
        currentLives = lives;
        //set the startPos
        startPos = transform.position;
        //Set the reference to the players attached rigidbody
        rigidBody = GetComponent<Rigidbody>();
        //controls health and ui health 
        // playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleJumping();
        LaserSpawner();
        MouseMovement();

        PlayerMoving();
    }


    /// <summary>
    /// lose a live and move the player back to startPos
    /// </summary>
    private void Respawn()
    {
        lives--;
        Debug.Log("Player took damage");
        //bring the player back to startPos
        transform.position = respawnPoint.position;
        Debug.Log("Player respawned");
        //check to see if player  has 0 lives
        if (lives <= 0)
        {
            Debug.Log("Player is Dead");
            
            SceneManager.LoadScene(3);
        }

        //UpdateHealthDisplay();
    }
    public void LaserSpawner()
    {
        if (Input.GetKey(KeyCode.E) && Time.time - lastSpawner >= spawnDelay)
        {
            Instantiate(laserPrefab, transform.position, cameraTransform.rotation);
            lastSpawner = Time.time;
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

    /// <summary>
    /// handles mana collection for the player
    /// </summary>
   // private void AddMana()
  //  {
     //   playerMana++;
    //    Debug.Log("Player mana has increased by 1");

  //  }

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
        if (other.gameObject.tag == "Mana")
        {
            // AddMana();
            playerMana++;
            Debug.Log("Mana collected");
            Destroy(other.gameObject);
           // if(playerMana>0 && !manaPrefabInstantiated)
            

            //    Instantiate(manaPrefab, transform.position, Quaternion.identity);
              //  manaPrefabInstantiated = true;
            //}
            
            // OnTriggerEnter
        }

        if(other.gameObject.tag == "Death")
        {
            Respawn();  
        }

        if(other.gameObject.tag == "Echoes")
        {
            playerEchoes++;
            other.gameObject.SetActive(false);
            Debug.Log("Collected an Echo");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            Debug.Log("collided with door");

            if(playerEchoes>= collision.transform.GetComponent<Keys>().echoesNeeded)
            {
                collision.gameObject.SetActive(false);
                playerEchoes-= collision.transform.GetComponent<Keys>().echoesNeeded;
                Debug.Log("opened the door");
            }
            else
            {
                Debug.Log("not enough echoes");
            }
        }

        if (collision.gameObject.tag == "Respawn")
        {
            Debug.Log("Hit checkpoint");
            respawnPoint.position = transform.position ;
            Debug.Log("Checkpoint saved");
        }
    }
    /// <summary>
    /// controls damage done in playerhealth script 
    /// </summary>
    /// <param name="damage"></param>
    //   public void TakeDamage()
    // {
    // lives -= damage;
    //     Respawn();

    //  }
    public int returnHealth()
    {
        return currentLives;
    }

    private void MouseMovement()
    {
        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSen * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSen * Time.deltaTime;

        xRotate -= mouseY;
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);  // Limits vertical rotation

        Player.localRotation = Quaternion.Euler(xRotate, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void PlayerMoving()
    {
        
        float horizontal = Input.GetAxis("Horizontal");  // A, D or Left, Right
        float vertical = Input.GetAxis("Vertical");      // W, S or Up, Down

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        transform.Translate(move * speed * Time.deltaTime, Space.World);
    }
}
