using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{

    public bool shieldActive;
    private Transform shield;

    public float time;

    void Start()
    {
        shieldActive = false;

        shield = GameObject.Find("ShieldEquip").GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        shieldActive = true;

        if(shieldActive == true)
        {
            transform.SetParent(shield);
            transform.localPosition = Vector3.zero;

            Invoke(nameof(ShieldDestroy), time);
        }
    }

    void ShieldDestroy()
    {
        Destroy(gameObject);
    }
}
