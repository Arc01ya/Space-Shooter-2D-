using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 3f;
    [SerializeField] float baseFiringRate = 2f;
   
    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float lastFireTime;
    [SerializeField] float shootTimeVariance = 0f;
    [SerializeField] float minShootTime = 0.2f;

    [HideInInspector] public bool isFiring;
    AudioPlayer audioPlayer;

    void Awake()
    {
       audioPlayer = FindAnyObjectByType<AudioPlayer>(); 
    }

   void Start()
   {  /* this method is from the tip in q&a, orig is way too complicated (lec. 122),
         orig method is to change to quarternion.euler(0,0,180) in spawnenemywaves method
         in enemy spawner script, so not really that  complicated*/
      if(useAI)
        {
            isFiring = true;

            projectileSpeed *= -1;
        }
   } 
 
    private void Update()
    {
        if (isFiring && CanFire())
        {
             ShootProjectile();
        }
       
    }
   
    private bool CanFire()
    {
        return Time.time - lastFireTime > baseFiringRate; //basically (a-b) > c
    }
 
    private void ShootProjectile()
    {
      //if(Input.GetKeyDown(KeyCode.E) == true) //for some reason, using while loop here crashes unity
         GameObject bullet = Instantiate(projectilePrefab,
                                        transform.position,
                                        Quaternion.identity);
       
         Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
          rb.linearVelocity = transform.up * projectileSpeed;
 
          Destroy(bullet, projectileLifetime);
          
          float shootTime = Random.Range(baseFiringRate - shootTimeVariance,
                                         baseFiringRate + shootTimeVariance);
          Mathf.Clamp(shootTime, minShootTime, float.MaxValue);
          audioPlayer.PlayShootingClip();
          lastFireTime = Time.time;
    }   // Update the last fire time
    

}  
  
   /* this is the method from lecture 121, modified from original where rapidly pressing fire could
      overcome firingRate, so in this version below while the firingrate problem got solved but now if 
      we keep the fire button pressed down it doesn't fire continuously ,so this is here in case i 
      find solution to this. i figured it out its bcoz in while statement for some reson if u put
      inputkeydown=e it only works when you put while(true),i'll still not use this bcoz too long and
      complicated*/

 /*   bool hasFired = false;
    Coroutine fireCoroutine;
    void Start()
    {
        
    }

    void Update()
    {
        Fire();
    }

   void Fire()
    {
       if(isFiring  && fireCoroutine == null && hasFired == false)
       {
          fireCoroutine = StartCoroutine(FireContinuously());
       }
       else if (!isFiring && fireCoroutine != null)
       {
         StopCoroutine(fireCoroutine);
         fireCoroutine = null;
         
       }
    }


    IEnumerator FireContinuously()
    {
       while(true )
       {
          GameObject instance = Instantiate(projectilePrefab, 
                                           transform.position, 
                                           Quaternion.identity);

          Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
          if(rb != null)
          {
            rb.velocity = transform.up * projectileSpeed;
          }
          
          Destroy(instance, projectileLifetime);
          
          //hasFired = true;
          StartCoroutine(FireControl());
          yield return new WaitForSeconds(firingRate);
         
       }
    }

    IEnumerator FireControl()
      {
         hasFired = true;
         yield return new WaitForSeconds(firingRate);
         hasFired = false;
      }*/