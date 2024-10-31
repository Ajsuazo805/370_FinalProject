using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public PlayerController playerController;
    //public PlayerHealth playerHealth;
    public TMP_Text healthText;
    public TMP_Text manaText;
    public PlayerMana playerMana;

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
    }
}
