using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public float healAmount = 1;

    [SerializeField]
    private AudioSource healCollect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            healCollect.Play();
            other.GetComponent<PlayerHealth>().Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
