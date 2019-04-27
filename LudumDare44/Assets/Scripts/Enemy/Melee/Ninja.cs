using System.Collections;
using System.Collections.Generic;
using Enemy.Interface;
using UnityEngine;

public class Ninja: MonoBehaviour, IDamageable<float>, IKillable, IEnemy
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

    private Transform shootPosition;
    
    private void Start()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        throw new System.NotImplementedException();
    }

    public void Damage(float damageTaken)
    {
        throw new System.NotImplementedException();
    }
    
    public void Kill()
    {
        throw new System.NotImplementedException();
    }

    public void Move(float tarX, float tarY)
    {
        Vector3 targetVelocity = new Vector2(tarX * 10f, tarY * 10f);
        enemyBody.velocity = Vector3.SmoothDamp(enemyBody.velocity, targetVelocity, ref velocity, movementSmoothing);
    }

    public void Rotate(Vector3 direction)
    {
        throw new System.NotImplementedException();
    }

    public void Attack(float tarX, float tarY)
    {
        throw new System.NotImplementedException();
    }
}
