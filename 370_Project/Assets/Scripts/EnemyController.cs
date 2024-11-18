using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //adds a float for the health, to be used by the UI controller
    public float health;

    public float speed;

    private Transform target;

    public float distance;
    public Transform Player;
    public NavMeshAgent navMeshAgent;

    private void Start()
    {
        //Detects Player Position
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        distance = Vector3.Distance(this.transform.position, Player.position);

        if (distance < 10)
        {
            navMeshAgent.destination = Player.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //tests if collision is working for enemies when colliding with Player and the Girl
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Enemy collision");
        }
        if (collision.gameObject.tag == "Girl")
        {
            Debug.Log("Enemy collision");
        }
    }
}
