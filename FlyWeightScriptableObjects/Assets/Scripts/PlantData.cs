using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "plantData", menuName = "PlantData", order = 51)]
    public class PlantData : ScriptableObject
    {
        public enum THREAT {None, Low, Moderate, Height}

        [SerializeField] private string plantName;
        [SerializeField] private THREAT plantThreat;
        [SerializeField] private Texture icon;
        
        public string Name => plantName;
        public THREAT Threat => plantThreat;
        public Texture Icon => icon;
    }
}