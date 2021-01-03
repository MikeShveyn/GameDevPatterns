using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Script
{
    public class InputManager : MonoBehaviour
    {
        public GameObject actor;
        private Animator _anim;
        private Command _keyP;
        private Command _keyJ;
        private Command _keyK;
        private Command _upArrow;
        List<Command> _oldCommands= new List<Command>();

        private Coroutine _replayCoroutine;
        private bool _shouldStartReplay;
        private bool _isReplaying;
        
        private void Start()
        {
            _keyJ = new PerformJump();
            _keyK = new PerformKick();
            _keyP = new PerformPunch();
            _upArrow = new MoveForward();
            _anim = actor.GetComponent<Animator>();
            Camera.main.GetComponent<CameraFollow360>().player = actor.transform;
        }

        private void Update()
        {
            if(!_isReplaying)
                HandleInput();
            StartReplay();
        }

        private void StartReplay()
        {
            if (_shouldStartReplay && _oldCommands.Count > 0)
            {
                _shouldStartReplay = false;
                if (_replayCoroutine != null) //stop if coroutine is playing
                {
                    StopCoroutine(_replayCoroutine);
                }

                _replayCoroutine = StartCoroutine(ReplayCommands());
            }
            
        }
        
        private void HandleInput()
        {
            //HANDLE INPUT AND STORE COMMANDS
            if (Input.GetKeyDown(KeyCode.J))
            {
                _keyJ.Execute(_anim, true);
                _oldCommands.Add(_keyJ);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                _keyK.Execute(_anim,true);
                _oldCommands.Add(_keyK);
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                _keyP.Execute(_anim,true);
                _oldCommands.Add(_keyP);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _upArrow.Execute(_anim, true);
                _oldCommands.Add(_upArrow);
            }
            
            
            //Command Play and pLAY bACK
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _shouldStartReplay = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                UndoLastCommand();
            }
        }
        
        private IEnumerator ReplayCommands() //Replay commands from the List
        {
            _isReplaying = true;

            for (int i = 0; i < _oldCommands.Count; i++)
            {
                _oldCommands[i].Execute(_anim, true);
                yield return new WaitForSeconds(1f); 
            }

            _isReplaying = false;
        }

        void UndoLastCommand() // Play reverse commands and delete them from List
        {
            if (_oldCommands.Count > 0)
            {
                Command c = _oldCommands[_oldCommands.Count - 1];
                c.Execute(_anim, false);
                _oldCommands.RemoveAt(_oldCommands.Count - 1);
            }
           
        }
    }
}