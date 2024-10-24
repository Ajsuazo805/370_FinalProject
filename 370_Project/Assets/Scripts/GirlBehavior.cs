using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GirlBehavior : MonoBehaviour
{
    //Players transform position in game
    public Transform player;

    //Max distance the girl will keep between the player 
    public float followDistance = 3f;

    //speed for the girl to follow the player
    public float followSpeed = 1f;

    //girls spawn point
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position - player.forward * followDistance;

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            transform.LookAt(player);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Portal")
        {
            //reset the startPos to the spawnPoint location
            startPos = other.gameObject.GetComponent<Portal>().spawnPoint.transform.position;
            //teleport the player to the new startPos
            transform.position = startPos;
        }
    }

}
