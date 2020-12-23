using Interfaces;
using UnityEngine;

namespace Commands
{
    public class ClickCommand : ICommand
    {
        private GameObject _cube;
        private Color _color;
        private Color _prevColor;
        
        public ClickCommand(GameObject cube, Color color)
        {
            this._cube = cube;
            this._color = color;
        }
        
        public void Execute()
        {
            //CHANGE THE COLOR OF TJE CUBE TO A RANDOM COLOR
            _prevColor = _cube.GetComponent<MeshRenderer>().material.color;
            _cube.GetComponent<MeshRenderer>().material.color = _color;
        }

        public void Undue()
        {
            _cube.GetComponent<MeshRenderer>().material.color = _prevColor;
        }

        public void AllWhite()
        {
            _cube.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}