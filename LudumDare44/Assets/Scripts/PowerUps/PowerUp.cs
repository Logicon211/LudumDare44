using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{

    // Prefab for powerup overlay
    public GameObject powerUpOverlay;

    // Actual overlay used by the object
    private GameObject overlay;
    private SpriteRenderer overlaySpriteRenderer;

    private bool pickupable;
    // Start is called before the first frame update
    public void Start()
    {
        pickupable = false;
        overlay = InstantiatePowerUpOverlay();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPickupable())
        {
            Pickup();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision Enter");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision With Player Enter");
            EnablePowerUpOverlay();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Collision Exit");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collision With Player Exit");
            DisablePowerUpOverlay();
        }
    }

    private GameObject InstantiatePowerUpOverlay()
    {
        Vector3 overlayPosition = transform.position + new Vector3(0f, 3.5f);
        GameObject overlay = Instantiate(powerUpOverlay, overlayPosition, Quaternion.identity);
        overlaySpriteRenderer = overlay.GetComponent<SpriteRenderer>();
        overlaySpriteRenderer.enabled = false;
        return overlay;
    }

    private void EnablePowerUpOverlay()
    {
        pickupable = true;
        overlaySpriteRenderer.enabled = true;
    }

    private void DisablePowerUpOverlay()
    {
        pickupable = false;
        overlaySpriteRenderer.enabled = false;
    }
    private bool IsPickupable()
    {
        return pickupable;
    }
    
    void Pickup()
    {
        PowerUpEffect();
        Destroy(overlay);
        Destroy(gameObject);
    }

    public abstract void PowerUpEffect();

}
