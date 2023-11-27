using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{

    public NavMeshAgent enemy;
    public Transform Player;

    public int damage = 1;

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            
        }
    }
}
