using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    public NavMeshAgent friend;
    public Transform Player;



    // Update is called once per frame
    void Update()
    {
        friend.SetDestination(Player.position);
    }
}
