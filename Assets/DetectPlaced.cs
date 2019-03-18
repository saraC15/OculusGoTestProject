using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlaced : MonoBehaviour
{
    public List<GameObject> currentCollisions = new List<GameObject>();
    void OnCollisionEnter (Collision collision)
    {
        GameObject placedObj = collision.gameObject;
        if (placedObj.tag == "Crop")
        {
            currentCollisions.Add(placedObj);
            Debug.Log("You placed " + placedObj.name + " on " + gameObject.name);
        } 
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject removedObj = collision.gameObject;
        if (removedObj.tag == "Crop")
        {
            currentCollisions.Remove(removedObj);
            Debug.Log("You removed " + removedObj.name + " from " + gameObject.name);
        }
    }
}
