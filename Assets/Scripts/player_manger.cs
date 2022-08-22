using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_manger : MonoBehaviour
{
   //for powers ups double jump etc
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collide" + other.tag);
        if (other.tag == "Player_Main")
        {
            Debug.Log("collide2" + other.tag);
            other.gameObject.GetComponent<main_player>().SetJumpRefresh(true);
            Debug.Log("Set Jump called");
        }

    }
}
