using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
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
