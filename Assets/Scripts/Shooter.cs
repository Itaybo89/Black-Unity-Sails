using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 1f;

    [Header("AI")]
    [SerializeField] float minimumFiringRate = 0.2f;
    [SerializeField] float firingRateVariance = 0.5f;
    [SerializeField] bool useAI;
    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();    
    }
    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
       Fire(); 
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
        firingCoroutine = StartCoroutine(FireContinuosly());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuosly()
    {
        while(true)
        {
           GameObject instance = Instantiate(projectilePrefab, 
                                            transform.position, 
                                            Quaternion.identity);
            
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed; 
            }
            Destroy(instance, projectileLifetime);
            if(!useAI) {audioPlayer.PlayShootingClip();}
            float rate = GetRandomFiringRate();
            yield return new WaitForSeconds (rate);
            
            
            

        }
        
    }
    public float GetRandomFiringRate()
    {
        float randomFiringRate = Random.Range(firingRate - firingRateVariance,
                                        firingRate + firingRateVariance);
        return Mathf.Clamp(randomFiringRate, minimumFiringRate, float.MaxValue);


    }
   
}
