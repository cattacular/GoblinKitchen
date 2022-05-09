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
    public int numOfOrders = 5;

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
        if(orderTimer > orderIntervals)
        {
            if(checkAvailableSpots())
            {
                orderCount++;
                GameObject order = Instantiate(orderNote, orderNoteSpots[orderSpot].position, orderNoteSpots[orderSpot].rotation);
                order.GetComponent<OrderNote>().orderNumber = orderCount;
                orderTimer = 0;
            }

            if(orderCount >= numOfOrders){
                GetComponent<OrderAreaController>().enabled = false;
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
            return true;
        }
        return false;
    }

}
