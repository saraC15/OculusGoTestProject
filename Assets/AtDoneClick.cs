using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtDoneClick : MonoBehaviour
{
    public GameObject Sweden;
    public GameObject Jordan;
    private List<GameObject> swedenCrops;
    private List<GameObject> jordanCrops;
    private readonly double lowThreshold = 1;
    private readonly double highThreshold = 4;

    public void Done()
    {
        swedenCrops = Sweden.GetComponent<DetectPlaced>().currentCollisions;
        jordanCrops = Jordan.GetComponent<DetectPlaced>().currentCollisions;
        Debug.Log("Done");

        string JordanCropsString = "Crops added to Jordan are ";

        foreach(var Crop in jordanCrops)
        {
            JordanCropsString += Crop.name + " ";
        }
        Debug.Log(JordanCropsString);

        string SwedenCropsString = "Crops added to Sweden are ";

        foreach (var Crop in swedenCrops)
        {
            SwedenCropsString += Crop.name + " ";
        }
        Debug.Log(SwedenCropsString);

        CorrectAndFeedback();
    }

    void CorrectAndFeedback()
    {
        //check if more than 3 crops on either plane
        if(swedenCrops.Count > 3 || jordanCrops.Count > 3)
        {
            Debug.Log("You may not choose more than three crops per country.");
            Debug.Log("Remove some and try again.");
        }
        else
        {
            //check if all crops suit the climate

            //check if no high water consuming crops

            //check if all crops have low water consumption

            //check if maximum amount of crops have been recommended 

        }
    }
}
