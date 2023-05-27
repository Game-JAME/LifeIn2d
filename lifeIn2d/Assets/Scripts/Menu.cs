using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
   sceneLoader SceneLoader;
   void Start()
   {
      SceneLoader = FindObjectOfType<sceneLoader>();
   }
   public void Play(){
      SceneLoader.LoadLevel(1);
   }
   public void Quit(){
    Application.Quit();
    Debug.Log("Quit");
   }
}
