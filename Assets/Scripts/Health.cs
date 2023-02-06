using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] bool isPlayer;
   [SerializeField] int health = 50;
   [SerializeField] ParticleSystem hitEffect;
   CameraShake cameraShake;
   [SerializeField] bool applyCameraShake;
   AudioPlayer audioPlayer;
   Player player;
   ScoreKeeper scoreKeeper;
   [SerializeField] int enemyValue = 100;
   LevelManager levelManager;

   

    void Awake() 
    {
        levelManager = FindObjectOfType<LevelManager>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        player = FindObjectOfType<Player>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
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


    void TakeDamage(int damage)
    {       
        health -= damage;
        if (health <= 0)
        {
            // if (player.gameObject != gameObject) 
            // { 
            //     scoreKeeper.ScoreIncrement(enemyValue); 
            // }
            Die();
        }
    }
    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    void Die()
    {
        if (!isPlayer) 
        { 
            scoreKeeper.ScoreIncrement(enemyValue); 
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }
}

