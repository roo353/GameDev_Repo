using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //looks for the object with the tag "Player"
        {
        //teleports player to the teleportation point
        TeleportPlayer(collision.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        GameObject teleportPoint = GameObject.Find("TeleportPoint");

        if (teleportPoint != null)
        {
            //Teleports player to teleport point position
            player.transform.position = teleportPoint.transform.position;
        }
        
        else
        {
            Debug.Log("Teleport point not found!");
        }
    }
    //Script from previous assignment
}