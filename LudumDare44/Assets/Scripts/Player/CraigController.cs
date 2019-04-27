using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraigController : MonoBehaviour
{

    private Rigidbody2D PlayerRigidBody;
    private Vector3 velocity = Vector3.zero;
    private float horizontalMove;
    private float verticalMove;

    public float defaultPlayerSpeed = 4f;
    public float playerspeed = 4f;
    

    private float maxHealth = 140f;
    private float health = 140f;
    private float energy = 0f;
    private float bulletVelocity = 50f;
    
    public GameObject bullet;
    public AudioClip hurtSound;
    public AudioClip shotgunSound;

    public GameObject gameControllerObject;
    private GameManager gameManager;

    private bool LeftClickDown;
    private bool LeftClick;
    private bool RightClick;
    private bool RightClickRelease;
    private bool RightClickDown;
    private float punchCharge;
    Vector2 direction;
    private bool SpacebarDown;
    private bool Dodging;
    private Vector2 DodgeDirection;
    private Vector2 NewPos;
    private float dodgeCooldown;
    Animator animator;
    private bool punchCharging;
    private Vector2 punchChargeDirection;
    private bool punching;
    private float punchCooldown;
    private Vector2 punchDirecion;

    private bool usingShotgun = true;
   
    private AudioSource AS;
    private GameObject particles;

    private Transform shootPosition;

    private int BASE_ANIMATION_LAYER = 0;
    private int SHOTGUN_ANIMATION_LAYER = 1;
    private int LAZER_ANIMATION_LAYER = 2;

    // Use this for initialization
    void Start()
    {
        if (gameControllerObject == null)
        {
            gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        }
        gameManager = gameControllerObject.GetComponent<GameManager>();
        PlayerRigidBody = this.GetComponent<Rigidbody2D>();
        Dodging = false;
        NewPos = transform.position;
        animator = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
        shootPosition = transform.Find("ShootPosition");
        particles = transform.Find("ParticleEffect").gameObject;
        animator.SetLayerWeight(BASE_ANIMATION_LAYER, 0f);
        animator.SetLayerWeight(SHOTGUN_ANIMATION_LAYER, 100f);
        animator.SetLayerWeight(LAZER_ANIMATION_LAYER, 0f);
    }

    // Update is called once per frame
    void Update()
    {

        //Get Movement unputs
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        //Get Action inputs
        LeftClickDown = Input.GetButtonDown("Fire1");
        LeftClick = Input.GetButton("Fire1");
        RightClick = Input.GetButton("Fire2");
        RightClickRelease = Input.GetButtonUp("Fire2");
        RightClickDown = Input.GetButtonDown("Fire2");
        SpacebarDown = Input.GetButtonDown("Jump");

        //Player rotation to mouse          
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        direction = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        direction.Normalize();

            PlayerRigidBody.mass = 1;
                      
        




        if (direction != Vector2.zero)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }
        else
        {
            PlayerRigidBody.freezeRotation = false;
        }

        // if(SpacebarDown == true && !Dodging){
        //     Dodging = true;
        //     dodgeCooldown = 0.25f;
        // 	DodgeDirection = NewPos;
        // 	DodgeDirection.Normalize ();
        // }

       
        //PlaYer movement
        //if (!Dashing && !Dodging)
        //{
            NewPos = Vector3.Normalize(new Vector2(horizontalMove * playerspeed, verticalMove * playerspeed));
            PlayerRigidBody.velocity = playerspeed * NewPos;
            if (horizontalMove != 0f || verticalMove != 0f)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }

        //}
       
        // if(Dodging){
        //     PlayerRigidBody.velocity = 35 * DodgeDirection;
        // 	dodgeCooldown -= Time.fixedDeltaTime;
        //     if(dodgeCooldown <= 0){
        //         Dodging=false;
        //     }

        // }


        if (LeftClickDown && !gameManager.IsPaused())
        {
            ShootShotgun();
            animator.SetTrigger("ShootGun");   
        }
    }


    private void FixedUpdate()
    {

    }

  
    /*
        Takes an int corresponding to the current powerup craig will get
         0 - nothing
         1 - Laser
         2 - Shotgun
         3 - Health
         4 - Wrench?
         5 - Speed Boost
         6 - Shiny Teeth
    */
    public void SetPowerUp(int powerupValue)
    {
        //Do Stuff
    }

    public void Damage(float damageTaken)
    {
            health -= damageTaken;
            AS.PlayOneShot(hurtSound); 
    }

    public float GetHealth()
    {
        return health;
    }


    
    public void PickupHealth()
    {
        health += 15f;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    
    

    public void ShootShotgun()
    {
        AS.PlayOneShot(shotgunSound);

        Quaternion rotation = transform.rotation;
        rotation *= Quaternion.Euler(Vector3.forward * 90);

        GameObject projectileLaunched = Instantiate(bullet, shootPosition.position, rotation) as GameObject;
        GameObject projectileLaunched2 = Instantiate(bullet, shootPosition.position, rotation) as GameObject;
        GameObject projectileLaunched3 = Instantiate(bullet, shootPosition.position, rotation) as GameObject;
        GameObject projectileLaunched4 = Instantiate(bullet, shootPosition.position, rotation) as GameObject;
        GameObject projectileLaunched5 = Instantiate(bullet, shootPosition.position, rotation) as GameObject;
        GameObject projectileLaunched6 = Instantiate(bullet, shootPosition.position, rotation) as GameObject;
        GameObject projectileLaunched7 = Instantiate(bullet, shootPosition.position, rotation) as GameObject;
        GameObject projectileLaunched8 = Instantiate(bullet, shootPosition.position, rotation) as GameObject;
        GameObject projectileLaunched9 = Instantiate(bullet, shootPosition.position, rotation) as GameObject;

        projectileLaunched.transform.Rotate(0, 0, Random.Range(-15, 15));
        projectileLaunched2.transform.Rotate(0, 0, Random.Range(-15, 15));
        projectileLaunched3.transform.Rotate(0, 0, Random.Range(-15, 15));
        projectileLaunched4.transform.Rotate(0, 0, Random.Range(-15, 15));
        projectileLaunched5.transform.Rotate(0, 0, Random.Range(-15, 15));
        projectileLaunched6.transform.Rotate(0, 0, Random.Range(-15, 15));
        projectileLaunched7.transform.Rotate(0, 0, Random.Range(-15, 15));
        projectileLaunched8.transform.Rotate(0, 0, Random.Range(-15, 15));
        projectileLaunched9.transform.Rotate(0, 0, Random.Range(-15, 15));
        projectileLaunched.GetComponent<Rigidbody2D>().velocity = projectileLaunched.transform.right * (bulletVelocity + Random.Range(-2, 2));
        projectileLaunched2.GetComponent<Rigidbody2D>().velocity = projectileLaunched2.transform.right * (bulletVelocity + Random.Range(-2, 2));
        projectileLaunched3.GetComponent<Rigidbody2D>().velocity = projectileLaunched3.transform.right * (bulletVelocity + Random.Range(-2, 2));
        projectileLaunched4.GetComponent<Rigidbody2D>().velocity = projectileLaunched4.transform.right * (bulletVelocity + Random.Range(-2, 2));
        projectileLaunched5.GetComponent<Rigidbody2D>().velocity = projectileLaunched5.transform.right * (bulletVelocity + Random.Range(-2, 2));
        projectileLaunched6.GetComponent<Rigidbody2D>().velocity = projectileLaunched6.transform.right * (bulletVelocity + Random.Range(-2, 2));
        projectileLaunched7.GetComponent<Rigidbody2D>().velocity = projectileLaunched7.transform.right * (bulletVelocity + Random.Range(-2, 2));
        projectileLaunched8.GetComponent<Rigidbody2D>().velocity = projectileLaunched8.transform.right * (bulletVelocity + Random.Range(-2, 2));
        projectileLaunched9.GetComponent<Rigidbody2D>().velocity = projectileLaunched9.transform.right * (bulletVelocity + Random.Range(-2, 2));

        
    }


}
