using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
   [SerializeField] int damage = 10;
   [SerializeField] bool isEnemy;

   public int GetDamage()
   {
      return damage;
   }

   public void Hit()
   {
      if (isEnemy) {Destroy(gameObject);}
   }

}

/* bullet collision script which i wrote myself, obv doesnt work
      [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool projectile;


    void OnTriggerEnter2D(Collider2D other)
    {
      if(projectile)
      {
        PlayHitEffect();
      }  
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, quaternion.identity);
            Destroy(instance.gameObject);
        } 
    }
*/