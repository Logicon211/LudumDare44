using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour
{

    public float speed = 10f;
    public float maxHealth = 100f;
    public float currentHealth = 0f;
    public HealthBar healthBar;
    public CooldownBar cooldownBar;
    
    // Start is called before the first frame update
    void Start()
    {
        cooldownBar = GameObject.FindWithTag("Cooldown Bar").GetComponent<CooldownBar>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalSpeed = speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float verticalSpeed = speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        
        transform.position += new Vector3(horizontalSpeed, verticalSpeed);

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P Pressed");
            currentHealth = cooldownBar.SetCooldown(currentHealth - 0.05f);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("O Pressed");
            currentHealth = cooldownBar.SetCooldown(currentHealth + 0.05f);
        }
    }
}
