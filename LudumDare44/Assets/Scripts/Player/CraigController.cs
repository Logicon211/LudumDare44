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


    private float heat = 0;
    private int heatMax = 100;
    private float cooldown = 0;
    private float heatcooldowndelaytimer;
    private float heatCooldownAccelBase = 2f;
    private float heatCooldownAccel = 0f;

    //Modular upgrade
    private int spread = 1;
    private float fireRate = 0.1f;
    private float damage = 3f;


    private float heatCost = 5f;
    private float craigSpeed = 5f;
    private float bulletVolume = 50f;

    //Bullet speed
    //One time upgrades:
    private bool knockback;
    private bool heatCooldownDelay;
    private bool bulletTime;
    private bool healthRegenUp;
    private bool explodingEnemies;

    //Joke upgrades
    //Gun sound
    //Jeans




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
        //LeftClickDown = Input.GetButtonDown("Fire1");
        LeftClickDown = Input.GetButton("Fire1");
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


//        Debug.Log(heat);



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
            
        }
        else
        {
            if (heatcooldowndelaytimer > 0)
            {
                heatcooldowndelaytimer = heatcooldowndelaytimer - Time.deltaTime;

            }
            else if (heat > 0)
            {
                heatCooldownAccel = heatCooldownAccel + (0.4f * Time.deltaTime);
                if (heat - heatCooldownAccel < 0)
                {
                    heat = 0;
                }
                else
                {
                    heat = heat - heatCooldownAccel;
                }
            }
        }


        cooldown = cooldown -Time.deltaTime;


        //cooldown heat timer

        

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
        if (cooldown <= 0)
        {

        AS.PlayOneShot(shotgunSound);

        Quaternion rotation = transform.rotation;
        rotation *= Quaternion.Euler(Vector3.forward * 90);


//Spread = 1;
//fireRate = 1.5f;
//damage = 3f;
//heatCooldownAccel = 1;
//heatCost = 5f;
//craigSpeed = 5f;
//bulletVolume = 50f;


        for (int i = 0; i<spread; i++) {
            GameObject projectileLaunched = Instantiate(bullet, shootPosition.position, rotation) as GameObject;
            projectileLaunched.GetComponent<BulletController>().setValues(damage, knockback);
            projectileLaunched.transform.Rotate(0, 0, Random.Range(-5, 5));
            projectileLaunched.GetComponent<Rigidbody2D>().velocity = projectileLaunched.transform.right * (bulletVelocity + Random.Range(-2, 2));

        }
            animator.SetTrigger("ShootGun");
            heat += heatCost;
            //Debug.Log(heat);
            
            cooldown = fireRate + (0.4f * (heat/heatMax));
            if (!heatCooldownDelay)
            {
                heatcooldowndelaytimer = 1f;
            }
            else
            {
                heatcooldowndelaytimer = 0.4f;
                heatCooldownAccel = heatCooldownAccelBase;
            }
            
            //Debug.Log(cooldown);
            if (heat >= heatMax)
            {
                //OVERHEAT
            }
            
    }
    }//End of cooldown

}
