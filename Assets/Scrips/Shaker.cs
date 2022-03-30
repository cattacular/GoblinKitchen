using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Shaker : MonoBehaviour
{

    public int totalContents = 1024;
    public GameObject shakerContentsPrefab;
    public float shakerTiltThreshold = -0.6f;
    private Rigidbody rb;
    public float velocityHighThreshold = 5f;
    public float velocityLowThreshold = 0.1f;
    private MeshCollider lidCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lidCollider = GetComponentInChildren<MeshCollider>();

    }
    void FixedUpdate()
    {
        if(transform.up.y < shakerTiltThreshold && totalContents > 0){
            SpawnShakerContent();
        }
    }

    void SpawnShakerContent()
    {

        Instantiate(shakerContentsPrefab, RandomLidSpot(), transform.rotation);
        totalContents--;
    }

    private Vector3 RandomLidSpot()
    {
        float x = Random.Range(lidCollider.bounds.min.x, lidCollider.bounds.max.x);
        float y = Random.Range(lidCollider.bounds.min.y, lidCollider.bounds.max.y);
        float z = Random.Range(lidCollider.bounds.min.z, lidCollider.bounds.max.z);

        return new Vector3(x,y,z);
    }
}
