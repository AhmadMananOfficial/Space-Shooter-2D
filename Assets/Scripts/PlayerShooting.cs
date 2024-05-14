using UnityEngine;

//guns objects in 'Player's' hierarchy
[System.Serializable]
public class Guns
{
    public GameObject rightGun, leftGun, centralGun;
    [HideInInspector] public ParticleSystem leftGunVFX, rightGunVFX, centralGunVFX; 
}

public class PlayerShooting : MonoBehaviour {

    public static PlayerShooting instance;
    [Tooltip("shooting frequency. the higher the more frequent")]
    [SerializeField] private float fireRate;
    [Tooltip("projectile prefab")]
    [SerializeField] private GameObject projectileObject;
    [Range(1, 3)] [Tooltip("current weapon power")]
	public int weaponPower = 1;
    
    [SerializeField] private Guns guns;  
    [SerializeField] private SoundManager soundManager;

    private bool shootingIsActive = true;
	private float nextFire; //time for a new shot

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        //receiving shooting visual effects components
        guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();
        guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();
	    guns.centralGunVFX = guns.centralGun.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (shootingIsActive && Time.time > nextFire)
        {
	        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                MakeAShot();                                                         
                nextFire = Time.time + 1 / fireRate;
            }
        }
    }

    //method for a shot
	private void MakeAShot() 
    {
        switch (weaponPower) // according to weapon power 'pooling' the defined anount of projectiles, on the defined position, in the defined rotation
        {
            case 1:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                guns.centralGunVFX.Play();
                break;
            case 2:
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, Vector3.zero);
                guns.leftGunVFX.Play();
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, Vector3.zero);
                guns.rightGunVFX.Play();
                break;
            case 3:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, Vector3.zero);
                guns.leftGunVFX.Play();
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, Vector3.zero);
                guns.rightGunVFX.Play();
                break;
        }
	    
    }

	private void CreateLazerShot(GameObject lazer, Vector3 pos, Vector3 rot) //translating 'pooled' lazer shot to the defined position in the defined rotation
    {
	    GameObject bullet = Instantiate(lazer, pos, Quaternion.Euler(0,0, 270));
	    soundManager.ShootingSFX();
	    
	    // Start the bullet destruction timer
	    Destroy(bullet, 1f);
    }
}
