using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public string title;
    public float quality = 100;

    public void onWindow(int time){
        Invoke("Destroy", time);
    }
}
