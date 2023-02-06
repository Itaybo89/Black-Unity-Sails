using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
   [Header("AudioSource")]
   [SerializeField] AudioClip mainClip;    
   [SerializeField] AudioClip gameClip;
   [SerializeField] AudioClip endClip;

   [Header("shooting")]
   [SerializeField] AudioClip shootingClip;
   [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;
   [Header("taking damage")]
   [SerializeField] AudioClip damagedClip;
   [SerializeField] [Range(0f, 1f)] float damagedVolume = 1f;
   AudioSource audioSource;

   static AudioPlayer instance;
   

   // void Awake() 
   // {
   //    audioSource = GetComponent<AudioSource>(); 
   //    ManageSingleton();   
   // }

   // void ManageSingleton()
   // {
   //   if (instance != null)
   //   {
   //      gameObject.SetActive(false);
   //      Destroy(gameObject);
   //   }
   //   else
   //   {
   //      instance = this;
   //      DontDestroyOnLoad(gameObject);
   //   }
   // }
   public void PlayShootingClip()
   {
      PlayClip(shootingClip, shootingVolume);
   }
   public void PlayDamageClip()
   {
       PlayClip(damagedClip, damagedVolume);
   }
   void PlayClip(AudioClip clip, float volume)
   {
      if(clip != null)
      {
          Vector3 cameraPos = Camera.main.transform.position;
          AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
      } 
   }

   // public void AudioSourceMain()
   // { 
   //    audioSource.clip = mainClip;
   // }
   // public void AudioSourceGame()
   // { 
   //    audioSource.clip = gameClip;
   // }
   // public void AudioSourceEND()
   // { 
   //    audioSource.clip = endClip;
   // }

}
