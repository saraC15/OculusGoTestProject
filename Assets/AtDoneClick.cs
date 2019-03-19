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

        foreach(var crop in jordanCrops)
        {
            JordanCropsString += crop.name + " ";
        }
        Debug.Log(JordanCropsString);

        string SwedenCropsString = "Crops added to Sweden are ";

        foreach (var crop in swedenCrops)
        {
            SwedenCropsString += crop.name + " ";
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
            List<GameFacts> swedenCropsFacts = GetCropFacts(swedenCrops);
            List<GameFacts> jordanCropsFacts = GetCropFacts(jordanCrops);

            bool maximumAmountOfCropsSelected = (swedenCropsFacts.Count == 3 && jordanCropsFacts.Count == 3);

            bool cropsSuiteClimate = true;
            bool noHighWater = true;
            bool allLowWater = true;

            foreach (var cropFact in jordanCropsFacts)
            {
                int waterPerCalorie = cropFact.WaterConsumption / cropFact.CaloriesPerKg;
                cropsSuiteClimate = cropsSuiteClimate && cropFact.ClimateJordanOk;
                noHighWater = noHighWater && (waterPerCalorie < highThreshold);
                allLowWater = allLowWater && (waterPerCalorie < lowThreshold);
            }

            foreach (var cropFact in swedenCropsFacts)
            {
                int waterPerCalorie = cropFact.WaterConsumption / cropFact.CaloriesPerKg;
                cropsSuiteClimate = cropsSuiteClimate && cropFact.ClimateSwedenOk;
                noHighWater = noHighWater && (waterPerCalorie < highThreshold);
                allLowWater = allLowWater && (waterPerCalorie < lowThreshold);
            }

            int points = 0;
            if (maximumAmountOfCropsSelected)
            {
                points++;
            }
            if (cropsSuiteClimate)
            {
                points++;
            }
            if (noHighWater || allLowWater)
            {
                points++;
            }
            if (allLowWater)
            {
                points++;
            }

            Debug.Log("You recieved " + points + "/4 points.");

            if (!allLowWater)
            {
                Debug.Log("- You could have chosen more water efficient foods.");
            }
            if (!maximumAmountOfCropsSelected)
            {
                Debug.Log("- To make sure the market is not saturated you should pick");
                Debug.Log("maximum amount of possible foods to produce.");
            }
            if (!cropsSuiteClimate)
            {
                Debug.Log("- Not all foods you selected suit the given climate.");
            }
            if (!noHighWater)
            {
                Debug.Log("- You have chosen one or more foods with a very high");
                Debug.Log("water consumption.");
            }
        }
    }

    private List<GameFacts> GetCropFacts(List<GameObject> cropObjects)
    {
        List<GameFacts> cropFacts = new List<GameFacts>();
        foreach (GameObject crop in cropObjects)
        {
            cropFacts.Add(crop.GetComponent<GameFacts>());
        }

        return cropFacts;
    }
}
