using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameFacts_Blueberry : MonoBehaviour, IGameFact
{
    public int WaterConsumption { get; set; }
    public bool ClimateSwedenOk { get; set; }
    public bool ClimateJordanOk { get; set; }
    public int CaloriesPerKg { get; set; }
}
