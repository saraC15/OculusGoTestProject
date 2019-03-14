using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlaced : MonoBehaviour
{
    void OnCollisionEnter (Collision collision)
    {
        GameObject placedObj = collision.gameObject;
        if (placedObj.tag == "Crop")
        {
            Debug.Log("You placed " + placedObj.name + " on " + gameObject.name);
        } 
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject removedObj = collision.gameObject;
        if (removedObj.tag == "Crop")
        {
            Debug.Log("You removed " + removedObj.name + " from " + gameObject.name);
        }
    }
}
