using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingredient : MonoBehaviour
{
    public float[] heatTimes = {0f, 1f,2f,3f,4f};
    public string[] heatLevelName = {"raw","undercooked","just right","burnt","rock"};
    private bool isCooking;
    private int cookCount = 0;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking){
            if (cookCount < heatTimes.Length){
            if (timer < heatTimes[cookCount]){
                    timer += Time.deltaTime;
            } else {
                Debug.Log(heatLevelName[cookCount]);
                cookCount += 1;
                timer += Time.deltaTime;
            }
        }
        }
    }

    void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("heater"))
		{
			isCooking = true;
		}
	}
    
    void OnTriggerExit(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag("heater"))
		{
			isCooking = false;
		}
	}
}
