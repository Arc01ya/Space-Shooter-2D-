using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
  [Header("Shooting")]
  [SerializeField] AudioClip shootingClip;
  [SerializeField] [Range(0f, 1f)] float shootVolume = 1f;

  [Header("Damage")]
  [SerializeField] AudioClip damageClip;
  [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

  static AudioPlayer instance;

  void Awake()
  {
    ManageSingleton();
  }

  void ManageSingleton()
  {
    //int instanceCount =  FindObjectsOfType(GetType()).Length;
    if(instance != null)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else
    {
      instance = this; //this means set the instance variable equal to this object, indicates this version of audioplayer
      DontDestroyOnLoad(gameObject);
    }
  }

  public void PlayShootingClip()
  {
     PlayClip(shootingClip, shootVolume);
  }

    public void PlayDamageClip()
  {
     PlayClip(damageClip, damageVolume);
  }

  void PlayClip(AudioClip clip, float volume)
  {
    Vector3 cameraPos = Camera.main.transform.position;
    if (clip != null)
    {
       AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }
  }

}
