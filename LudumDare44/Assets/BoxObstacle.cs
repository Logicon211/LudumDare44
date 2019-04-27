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

            foreach(GameObject debrisPiece in debris) {
                GameObject part = Instantiate(debrisPiece, transform.position, Quaternion.identity);
                Rigidbody2D rb = part.GetComponent<Rigidbody2D>();
                Vector3 velocity = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
                velocity.Normalize();
                rb.AddForce(velocity * 1000f);
                rb.AddTorque(Random.Range(0f, 1000f));

            }
            // gameManager.DecreaseEnemyCount();
            Destroy(gameObject);
        }
    }
}
