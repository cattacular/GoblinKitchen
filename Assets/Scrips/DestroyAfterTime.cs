using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float selfDestructTime = 500f;
    void Start()
    {
        Destroy(this.gameObject, selfDestructTime);
    }
}
