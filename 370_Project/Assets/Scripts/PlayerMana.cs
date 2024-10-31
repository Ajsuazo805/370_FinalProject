using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMana : MonoBehaviour
{

    public int currentMana = 0;
    // public TMP_Text manaText;

    public void AddMana(int v)
    {
        currentMana += 1;
       // UpdateManaUI();
    }

}
