using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Interface;

public class BoxObstacle : MonoBehaviour, IDamageable<float>
{

    public GameObject explosion;
    public GameObject[] debris;

    public float health = 20f;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damageTaken)
    {
        health -= damageTaken;
        if (health <= 0f)
            Kill();
    }

    public void Kill()
    {
        if(!isDead) {
            isDead = true;
            Instantiate(explosion, transform.position, Quaternion.identity);
            // gameManager.DecreaseEnemyCount();
            Destroy(gameObject);
        }
    }
}
