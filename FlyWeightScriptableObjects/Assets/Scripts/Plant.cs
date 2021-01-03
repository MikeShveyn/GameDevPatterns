using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Plant : MonoBehaviour
    {
        [SerializeField] private PlantData info;
        SetPlantInfo spi;

        private void Start()
        {
            spi = GameObject.FindWithTag("PlantInfo").GetComponent<SetPlantInfo>();
        }

        private void OnMouseDown()
        {
            spi.OpenPlantPanel();
            spi.plantName.text = info.name;
            spi.phreatLevel.text = info.Threat.ToString();
            spi.plantIcon.GetComponent<RawImage>().texture = info.Icon;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Player") && info.Threat == PlantData.THREAT.Height)
            {
                PlayerController.dead = true;
            }
        }
    }
}