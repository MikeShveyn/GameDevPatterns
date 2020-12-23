using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

namespace Managers
{
    public class CommandManager : MonoBehaviour
    {
        //Singleton
        private static CommandManager _instance;//live over all instances of the class

        public static CommandManager Instance
        {
            get
            {
                if(_instance == null)
                    Debug.LogError("THe commandManager is Null");
                return _instance;
            }
        }
        
        private List<ICommand> _commandBuffer = new List<ICommand>();
        
        private void Awake()
        {
            _instance = this;
        }

        public void AddCommand(ICommand command)
        {
            _commandBuffer.Add(command);    
        }

        public void Play()
        {
            StopAllCoroutines();
            StartCoroutine(PlayTrigger());
        }

        private IEnumerator PlayTrigger()
        {
            foreach (var command in _commandBuffer)
            {
                command.Execute();
                yield return new WaitForSeconds(1f);
            }
        }

        public void Rewind()
        {
            StopAllCoroutines();
            StartCoroutine(RewindTrigger());
        }
        
        private IEnumerator RewindTrigger()
        {
            foreach (var command in Enumerable.Reverse(_commandBuffer))
            {
                command.Undue();
                yield return new WaitForSeconds(1f);
            }
        }

        public void Done()
        {
            var cubes = GameObject.FindGameObjectsWithTag("Cube");
            foreach (var cube in cubes)
            {
                cube.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
        

        public void Reset()
        {
            _commandBuffer.Clear();
        }
            
    }
}