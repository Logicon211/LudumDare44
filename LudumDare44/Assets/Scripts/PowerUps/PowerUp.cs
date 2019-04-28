using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{

    // Prefab for powerup overlay
    public GameObject powerUpOverlay;
    private HealthBar healthBar;

    // Actual overlay used by the object
    private GameObject overlay;
    private SpriteRenderer overlaySpriteRenderer;
    CraigController craig;

    private float overlayVerticalOffset = 12f;
    private float overlayScale = 4f;

    private bool pickupable;
    // Start is called before the first frame update
    public void Start()
    {
        pickupable = false;
        overlay = InstantiatePowerUpOverlay();
        healthBar = GameObject.FindWithTag("Health Bar").GetComponent<HealthBar>();
        craig = GameObject.FindGameObjectWithTag("Player").GetComponent<CraigController>();
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
        
        if (other.gameObject.tag == "Player")
        {
            
            EnablePowerUpOverlay();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            
            DisablePowerUpOverlay();
        }
    }

    private GameObject InstantiatePowerUpOverlay()
    {
        Vector3 overlayPosition = transform.position + new Vector3(0f, overlayVerticalOffset);
        GameObject overlay = Instantiate(powerUpOverlay, overlayPosition, Quaternion.identity);
        overlay.transform.localScale = new Vector3(overlayScale, overlayScale);
        overlaySpriteRenderer = overlay.GetComponent<SpriteRenderer>();
        overlaySpriteRenderer.enabled = false;
        return overlay;
    }

    private void EnablePowerUpOverlay()
    {
        pickupable = true;
        overlaySpriteRenderer.enabled = true;
        
        healthBar.ShowHealthLossPreview(GetHealthLossAmount());
    }

    private void DisablePowerUpOverlay()
    {
        pickupable = false;
        overlaySpriteRenderer.enabled = false;
        
        healthBar.HideHealthLossPreview();
    }
    private bool IsPickupable()
    {
        return pickupable;
    }
    
    void Pickup()
    {
        PowerUpEffect();
        Destroy(overlay);
        healthBar.HideHealthLossPreview();
        healthBar.DecreaseHealth(GetHealthLossAmount());
        float damage = craig.maxHealth * GetHealthLossAmount();
        craig.Damage(damage);
        Destroy(gameObject);
        
    }

    public abstract void PowerUpEffect();

    public abstract float GetHealthLossAmount();

    public abstract void SetHealthCostFree();
}
