using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
  
    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);        
    }

    public void UnityQuit(){
        Application.Quit();
    }

    public void Voltar(){

    SceneManager.LoadScene(0);        
        
    }
}
