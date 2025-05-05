using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCamerashake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake() 
    {
      cameraShake  = Camera.main.GetComponent<CameraShake>();   
      audioPlayer  = FindAnyObjectByType<AudioPlayer>(); 
      scoreKeeper  = FindAnyObjectByType<ScoreKeeper>();
      levelManager = FindAnyObjectByType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       DamageDealer damageDealer = other.GetComponent<DamageDealer>();    

       if (damageDealer != null)
       {
          TakeDamage(damageDealer.GetDamage());       
          PlayHitEffect();
          audioPlayer.PlayDamageClip();
          ShakeCamera();
          damageDealer.Hit();
       }
    }

   /* void OnTriggerEnterproj2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();    
         if(projectile)
         {
            PlayHitEffect();
            damageDealer.Hit();    
         }
    }*/

    void TakeDamage(int damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(!isPlayer)
        {
           scoreKeeper.ModifyScore(score);
        }
        else
        {
           levelManager.LoadEndScreen();
        }
    
        Destroy(gameObject);   
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        } 
    }

    public int Gethealth()
    {
        return health;
    }

    void ShakeCamera()
    {
        if (cameraShake != null && applyCamerashake)
        {
            cameraShake.Play();
        }
    }
}
