using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillJane : MonoBehaviour
{
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private float health = 10f;
    [SerializeField] private float shootCooldown = 5f;
    [SerializeField] private float attackDamage = 5f;
    [SerializeField] private float maxRangeToLandAttack = 7f;
    public Animator animator;

    public GameObject explosion;
    public GameObject poofEffect;
    public GameObject hitEffect;
    public AudioClip attackSound;

    public RoomController roomController;
	
    private AudioSource audio;
    private Rigidbody2D enemyBody;
    private Vector3 velocity = Vector3.zero;
    private float currentCooldown;
    private GameManager gameManager;
    private GameObject player;
    private EnemyController enemyController;

    private float currentHealth;
    private float attackDuration;
    private SpriteRenderer spriteRenderer;

    private bool isDead = false;
    private bool isAttacking = false;

    private Transform shootPosition;
    
    private void Awake() {
        enemyBody = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyController = GetComponent<EnemyController>();
        currentCooldown = 2f;
    }
    
    private void Start()
    {
        Instantiate(poofEffect, transform.position, Quaternion.identity);
        currentHealth = health;
    }

    private void Update()
    {

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
            Instantiate(explosion, transform.position, Quaternion.identity);
            if(roomController) {
                roomController.DecrementAliveEnemyCount();
            }
            Destroy(gameObject);
        }
    }

    public void Move(float tarX, float tarY)
    {
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
        animator.SetTrigger("Attack");
        audio.PlayOneShot(attackSound);
    }

    public void FinishPunch()
    {
        if(Vector2.Distance(player.transform.position, transform.position) <= maxRangeToLandAttack) {
            //TODO: Do damage to player
            var craigController = player.gameObject.GetComponent<CraigController>();
            craigController.Damage(attackDamage);
            Instantiate(hitEffect, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 0.1f), Quaternion.identity);
        }
    }
}
