using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public PlayerController playerController;
    //public PlayerHealth playerHealth;
    public TMP_Text healthText;
    public TMP_Text manaText;
    public TMP_Text echoesText;
    public PlayerMana playerMana;
    public PlayerController playerEchoes;


    // Update is called once per frame
    void Update()
    {
        if (healthText != null)
        {
            //healthText.text = "Health : " + playerHealth.GetHealth();
            healthText.text = "Health : " + playerController.lives.ToString();

        }

        if (manaText != null)
        {
          
            manaText.text = "Mana: " + playerController.playerMana.ToString();

        }

        if (playerEchoes != null)
        {

            echoesText.text = "Echoes: " + playerController.playerEchoes.ToString();

        }
    }
}
