using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{

    public GameObject powerUpOverlay;

    private bool pickupable;
    // Start is called before the first frame update
    void Start()
    {
        pickupable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision Enter");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision With Player Enter");
            pickupable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Collision Exit");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision With Player Exit");
            pickupable = false;
        }
    }

    public abstract void PickUp();

    public bool IsPickupable()
    {
        return pickupable;
    }
}
