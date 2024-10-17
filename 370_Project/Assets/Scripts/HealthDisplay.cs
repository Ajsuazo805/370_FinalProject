using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TMP_Text healthText;

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != null)
        {
            healthText.text = "Health : " + playerHealth.GetHealth();
        }
    }
}
