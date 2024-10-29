using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //adds a float for the health, to be used by the UI controller
    public float health;

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
