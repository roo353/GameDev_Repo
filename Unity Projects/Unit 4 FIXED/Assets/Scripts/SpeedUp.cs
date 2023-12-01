using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{

    public float addSpeed = 5f;
    public float timer = 5f;

    [SerializeField]
    private AudioSource speedCollect;
    
    void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Player"))
        {
            speedCollect.Play();
            StartCoroutine (PowerUpSpeed(other));
        }
    }

    IEnumerator PowerUpSpeed(Collider player)
    {
        PlayerMovement speedStat = player.GetComponent<PlayerMovement>();
            speedStat.speed += addSpeed;

            GetComponent<MeshCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;

            yield return new WaitForSeconds(timer);

            speedStat.speed -= addSpeed;

            Destroy(gameObject);
    }
}

