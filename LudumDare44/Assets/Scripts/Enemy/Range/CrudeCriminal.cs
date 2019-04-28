using System.Collections;
using System.Collections.Generic;
using Enemy.Interface;
using UnityEngine;
    
public class CrudeCriminal : MonoBehaviour, IEnemy, IKillable, IDamageable<float>
{
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private float health = 10f;
    [SerializeField] private float shootCooldown = 5f;
    public Animator animator;

    public GameObject explosion;
    public GameObject poofEffect;

    private AudioSource audio;
    private Rigidbody2D enemyBody;

    private Vector3 velocity = Vector3.zero;
    private float currentCooldown;
    private bool hasShot = true;
    private GameManager gameManager;

    private float currentHealth;
    SpriteRenderer spriteRenderer;

    private bool isDead = false;

    public RoomController roomController;
    public Transform shotLocation;
    public Transform explodeLocation;
    public GameObject projectile;

    public GameObject[] debris;

    private void Awake() {
        enemyBody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        currentCooldown = 2f;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = health;
        Instantiate(poofEffect, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        CheckAttackCooldown();
    }

    public void Damage(float damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= 0f && !isDead)
            Kill();
        if (health > currentHealth) 
        {
            var healthPercentage = currentHealth/health;
            spriteRenderer.color = new Color(1f, healthPercentage, healthPercentage);
        }
    }
    
    public void Kill()
    {
        if(!isDead) {
            isDead = true;
            Instantiate(explosion, explodeLocation.position, Quaternion.identity);
            if(roomController) {
                roomController.DecrementAliveEnemyCount();
            }

            foreach(GameObject debrisPiece in debris) {
                GameObject part = Instantiate(debrisPiece, explodeLocation.position, Quaternion.identity);
                Rigidbody2D rb = part.GetComponent<Rigidbody2D>();
                Vector3 velocity = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
                velocity.Normalize();
                rb.AddForce(velocity * 1000f);
                rb.AddTorque(Random.Range(0f, 500f));

            }

            Destroy(gameObject);
        }
    }

    public void Move(float tarX, float tarY)
    {
        animator.SetBool("moving", true);
        Vector3 targetVelocity = new Vector2(tarX * 10f, tarY * 10f);
        enemyBody.velocity = Vector3.SmoothDamp(enemyBody.velocity, targetVelocity, ref velocity, movementSmoothing);
    }
    
    public void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero) 
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
    }

    public void Attack(float tarX, float tarY)
    {
        // if(Vector2.Distance(player.transform.position, transform.position) <= attackRange) {
        //     //TODO: Do damage to player
        //     PlayerController playerController = player.gameObject.GetComponent<PlayerController>();
        //     playerController.Damage(attackDamage);
        //     Instantiate(hitEffect, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.1f), Quaternion.identity);
        // }
        animator.SetBool("moving", false);
        animator.SetTrigger("shootTrigger");
        audio.Play(0);
        GameObject bullet = Instantiate(projectile, shotLocation.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(tarX * 10f, tarY * 10f);
        hasShot = true;
    }

    public void StopMove() {
        animator.SetBool("moving", false);
    }


    private void CheckAttackCooldown()
    {
        if (hasShot) 
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0f) 
            {
                currentCooldown = shootCooldown;
                hasShot = false;
            }
        }
    }
}
