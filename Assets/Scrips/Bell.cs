using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Bell : XRSimpleInteractable
{
    public string nextScene;
    public AudioClip ding;
    public void foodDone()
    {
        StartCoroutine("PlayDing");
        if(FindObjectOfType<FoodWindow>().foodComplete){
            SceneManager.LoadScene(nextScene);
        }
    }

    IEnumerator PlayDing()
    {
        GetComponent<AudioSource>().Play();
        yield return null;
    }
}
