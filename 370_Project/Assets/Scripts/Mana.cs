using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{

    public int manaAmount = 1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMana playerMana = other.GetComponent<PlayerMana>();
            if (playerMana != null)
            {
                playerMana.AddMana(manaAmount);
                Destroy(gameObject);
            }
        }
    }
}
