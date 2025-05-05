using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    static ScoreKeeper instance;

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
   
    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0f, int.MaxValue);
        Debug.Log(score);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
