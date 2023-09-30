using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollect : MonoBehaviour
{
    private int coins = 0;
    public Text coinText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks for collision with coin
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject); //destroys coin
            coins++; //adds coins
            coinText.text = "Coins: " + coins;
        }
    }
}
