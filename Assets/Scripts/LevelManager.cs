using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;

    ScoreKeeper scoreKeeper;

   public void LoadGame()
   {
      scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
      if (scoreKeeper != null)
      {
        scoreKeeper.ResetScore(); 
      }
      SceneManager.LoadScene("Game");
   }

   public void LoadMainMenu()
   {
     SceneManager.LoadScene("MainMenu");
   }

   public void LoadEndScreen()
   {
     StartCoroutine(WaitAndLoad("EndScreen", sceneLoadDelay));
   }

    public void LoadCredits()
   {
     SceneManager.LoadScene("Credits");
   }

   public void QuitGame()
   {
      Debug.Log("Quitting Game...");
      Application.Quit();
   }
   IEnumerator WaitAndLoad(string sceneName, float delay)
   {
      yield return new WaitForSeconds(delay);
      SceneManager.LoadScene(sceneName);
   }
}
