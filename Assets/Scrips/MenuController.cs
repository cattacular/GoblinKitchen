using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void BeginGame(){
        SceneManager.LoadScene("Morning");
        Debug.Log("Yes it works");
    }

    public void BeginTutorial(){
        SceneManager.LoadScene("Tutorial");
    }

    public void ExitGame(){
        Application.Quit();
    }

}
