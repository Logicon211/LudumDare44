using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private Transform bar;
    private float currentHealth;

    private GameObject healthLossPreview;
    private Vector3 defaultHealthLossPreviewPos;
    private Vector3 defaultHealthLossPreviewScale;
    private float healthLossPreviewMaxWidth;
    private SpriteRenderer healthLossPreviewSpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        healthLossPreview = transform.Find("HealthLossPreview").gameObject;
        defaultHealthLossPreviewPos = healthLossPreview.transform.localPosition;
        defaultHealthLossPreviewScale = healthLossPreview.transform.localScale;
        healthLossPreviewSpriteRenderer = healthLossPreview.transform.Find("HealthLossPreviewSprite").gameObject
            .GetComponent<SpriteRenderer>();
        healthLossPreviewMaxWidth = healthLossPreviewSpriteRenderer.size.x;
        HideHealthLossPreview();
        currentHealth = 1f;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    // Increase health by a percentage and then return current health
    public float IncreaseHealth(float normalizedHealth)
    {
        currentHealth = Mathf.Min(1f, currentHealth + normalizedHealth);
        bar.localScale = new Vector3(currentHealth, 1f);
        return currentHealth;
    }

    // Decrease health by a percentage and then return current health
    public float DecreaseHealth(float normalizedHealth)
    {
        currentHealth = Mathf.Max(0f, currentHealth - normalizedHealth);
        bar.localScale = new Vector3(currentHealth, 1f);
        return currentHealth;
    }

    // Preview how much health will be lost if the power up is purchased.
    public void ShowHealthLossPreview(float normalizedHealth)
    {
        float healthToLose = Mathf.Min(normalizedHealth, currentHealth);
        healthLossPreview.transform.localScale = new Vector3(healthToLose, 1f);
        float healthLossPreviewOffset = currentHealth - healthToLose;
        healthLossPreview.transform.localPosition += new Vector3(healthLossPreviewOffset, 0f);
        healthLossPreviewSpriteRenderer.enabled = true;
    }

    public void HideHealthLossPreview()
    {
        healthLossPreviewSpriteRenderer.enabled = false;
        healthLossPreview.transform.localScale = defaultHealthLossPreviewScale;
        healthLossPreview.transform.localPosition = defaultHealthLossPreviewPos;
    }

    // Set health to a percentage and then return current health
    public float SetHealth(float normalizedHealth)
    {
        currentHealth = normalizedHealth;
        bar.localScale = new Vector3(currentHealth, 1f);
        return currentHealth;
    }

}
