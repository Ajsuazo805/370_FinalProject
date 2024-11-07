 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// handles teleporting using the f button 
/// </summary>
public class TeleportV2 : MonoBehaviour
{
    public GameObject Teleport;

    public PlayerController playerMana;

    public PlayerController playerController;

    public float manaRequired= 1f;

    // Start is called before the first frame update
    void Start()
    {
       // playerMana = GetComponent<PlayerController>().playerMana;
    }

    // Update is called once per frame
    void Update()
    {
        ManaTeleport();
    }
    /// <summary>
    /// controls the teleport to correspond with mana 
    /// </summary>
    public void ManaTeleport()
    {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (playerController.playerMana >= manaRequired)
                {
                    gameObject.transform.position = Teleport.transform.position;
                    Debug.Log("teleport Successful");
                playerController.playerMana--;
                }
               
            else
            {
                Debug.Log("not enough mana to teleport");
            }
                    
            }
           
           
    }

}

