using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlantInfo : MonoBehaviour
{
    public GameObject plantInfoPanel;
    public GameObject plantIcon;
    public Text plantName;
    public Text phreatLevel;
    
    

    public void OpenPlantPanel()
    {
        plantInfoPanel.SetActive(true);
    }

    public void ClosePlantPanel()
    {
        plantInfoPanel.SetActive(false);
    }
}
