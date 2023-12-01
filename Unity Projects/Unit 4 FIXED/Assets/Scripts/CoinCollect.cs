using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinCollect : MonoBehaviour
{

    public int coinValue = 1;

    [SerializeField]
    private AudioSource coinCollect;

     void OnTriggerEnter(Collider other)
     {
        if(other.gameObject.CompareTag("Player"))
        {
            coinCollect.Play();
            ScoreManager.instance.ChangeScore(coinValue);
            Destroy(gameObject);
        }
     }
}
