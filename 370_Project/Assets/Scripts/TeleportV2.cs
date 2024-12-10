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

    private bool teleportIsTrue = false;

    private float coolDown = 3f;

    [SerializeField]
    private float teleportDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        // playerMana = GetComponent<PlayerController>().playerMana;
        //StartCoroutine(TeleportTimer());
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
        
        if (Input.GetKeyDown(KeyCode.F)&& Time.time > coolDown)
            {
            
                if (playerController.playerMana >= manaRequired)
                {
                Vector3 teleportPosition = new Vector3(Teleport.transform.position.x, Teleport.transform.position.y, Teleport.transform.position.z);
                    gameObject.transform.position = teleportPosition;
                             Debug.Log("teleport Successful");
                playerController.playerMana--;
                coolDown = Time.time + teleportDelay;
                Debug.Log("teleport delay");
                //teleportIsTrue = true;
              //  StartCoroutine(TeleportTimer());
                
               
                
            }
               
            else
            {
                Debug.Log("not enough mana to teleport");
            }
                    
            }
           
           
    }
    private IEnumerator TeleportTimer()
    {
        
        Debug.Log("wait to teleport");
        yield return new WaitForSeconds(3);
        Debug.Log("you can now teleport");
       /// teleportIsTrue = false ;
    }

}

