using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
