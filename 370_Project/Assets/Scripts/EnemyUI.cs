using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    //adds spot in inspector to place intended enemy health and text
    public EnemyController enemy;
    public TMP_Text healthCount;

    // Update is called once per frame
    void Update()
    {
        //calls health to be displayed
        healthCount.text = "Health: " + enemy.health.ToString();
    }
}
