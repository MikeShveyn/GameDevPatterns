using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RealCase.RCInterface;
using TMPro;
using UnityEngine;

namespace RealCase.Managers
{
    public class InputCommandManger:MonoBehaviour
    {
        //Singleton
        private static InputCommandManger _inputInstance;
        
        public static InputCommandManger InputInstance
        {
            get
            {
                if(_inputInstance == null)
                    Debug.LogError("THe commandManager is Null");
                return _inputInstance;
            }
        }

        private List<IPlayerCommand> _playerCommandBuffer = new List<IPlayerCommand>();

        private void Awake()
        {
            _inputInstance = this;
        }

        public void AddCommand(IPlayerCommand playerCommand)
        {
            _playerCommandBuffer.Add(playerCommand);
        }
        
        
        public void Rewind()
        {
            StartCoroutine(RewindRoutine());
        }

        IEnumerator RewindRoutine()
        {
            foreach (var playerCommand in Enumerable.Reverse(_playerCommandBuffer))
            {
                playerCommand.Undue();
                yield return new WaitForEndOfFrame();
            }
        }
        
        public void Play()
        {
            StartCoroutine(PlayRoutine());
        }

        IEnumerator PlayRoutine()
        {
            foreach (var playerCommand in _playerCommandBuffer)
            {
                playerCommand.Execute();
                yield return new WaitForEndOfFrame();
            }
        }
    }
}