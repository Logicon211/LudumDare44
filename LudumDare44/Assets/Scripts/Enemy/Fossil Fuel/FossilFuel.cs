using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Enemy.Interface;
using UnityEngine;

public class FossilFuel : MonoBehaviour, IDamageable<float>, IEnemy, IKillable
{
    [Header("Boss Properties")]
    [SerializeField] private float health = 50f;
    [SerializeField] private float howBigABitchMitchIs = 100f;
    [SerializeField] private float movementSmoothing = 0.5f;
    [Header("Attack Properties")]
    [SerializeField] private float attackDuration = 5f;
    [SerializeField] private float attackCooldown = 3f;
    [Range(0f, 1f)][SerializeField] private float projectileSpawnRate = 0.2f;
    [Range(0f, 360f)][SerializeField] private float projectileSpread = 25f;
    [Range(0f, 50f)][SerializeField] private float projectileSpeed = 1f;
    [Header("Game Objects")]
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject projectile;
    
    private Rigidbody2D enemyBody;
    private Vector3 velocity = Vector3.zero;
    private Transform shotOriginatingLocation;
    private GameObject player;
    
    private float currentHealth;
    private float currentAttackDuration;
    private float currentAttackCooldown;
    private float currentProjectileCooldown;
    private bool isDead = false;
    private bool reloading = false;
    

    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        shotOriginatingLocation = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player");
        currentHealth = health;
        currentAttackCooldown = attackCooldown;
        currentAttackDuration = 0f;
        currentProjectileCooldown = projectileSpawnRate;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void Damage(float damageTaken)
    {
        currentHealth -= damageTaken;
        if (currentHealth <= 0f && !isDead)
            Kill();
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
        if (!reloading)
        {
            currentAttackDuration += Time.deltaTime;
            currentProjectileCooldown -= Time.deltaTime;
            if (currentAttackDuration >= attackDuration)
            {
                reloading = true;
                currentAttackDuration = 0f;
            }
            if (currentProjectileCooldown <= 0f)
            {
                Quaternion rotation = transform.rotation;
                var bullet = Instantiate(projectile, shotOriginatingLocation.position, rotation) as GameObject;
                bullet.transform.Rotate(0, 0, Random.Range(-projectileSpread, projectileSpread));
                bullet.GetComponent<Rigidbody2D>().velocity = projectileSpeed * bullet.transform.up;
                currentProjectileCooldown = projectileSpawnRate;
            }
        }
        else if (reloading)
        {
            currentAttackCooldown -= Time.deltaTime;
            if (currentAttackCooldown <= 0f)
            {
                reloading = false;
                currentAttackCooldown = attackCooldown;
            }
        }
        
    }

    public void Kill()
    {
        if(!isDead) {
            isDead = true;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
