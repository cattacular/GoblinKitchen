using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderAreaController : MonoBehaviour
{
    public float orderIntervals = 300;
    public float startingTime = 20;
    public GameObject orderNote;
    public Transform[] orderNoteSpots;
    public List<bool> openSpot = new List<bool>();
    private int orderSpot;
    public int orderCount = 0;

    private float orderTimer = 0; 

    void Start()
    {
        for(int i = 0; i < orderNoteSpots.Length; i++)
        {
            openSpot.Add(true);
        }

        orderTimer = orderIntervals - startingTime;

    }
    void Update()
    {
        orderTimer += Time.fixedDeltaTime;

        Debug.Log(orderTimer);
        if(orderTimer > orderIntervals)
        {
            Debug.Log("Entered if");
            if(checkAvailableSpots())
            {
                orderCount++;
                Instantiate(orderNote, orderNoteSpots[orderSpot].position, orderNoteSpots[orderSpot].rotation);
                orderTimer = 0;
            }
        }
    }

    private bool checkAvailableSpots()
    {
        int tempSpot = openSpot.IndexOf(true);
        Debug.Log(tempSpot);
        if(tempSpot >= 0 && tempSpot < orderNoteSpots.Length)
        {
            orderSpot = tempSpot;
            openSpot[tempSpot] = false;
            //MoveNotesForward()
            return true;
        }
        return false;
    }

    private void MoveNotesForward()
    {

    }
}
