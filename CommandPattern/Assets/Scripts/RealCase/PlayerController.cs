using Interfaces;
using Managers;
using RealCase.Commands;
using RealCase.Managers;
using RealCase.RCInterface;
using UnityEngine;

namespace RealCase
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayerCommand moveUp, moveDown, moveLeft, moveRight;
        [SerializeField]
        private float _speed = 2.0f;
   

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                //move up
                moveUp = new MoveUpCommand(this.transform, _speed);
                moveUp.Execute();
                InputCommandManger.InputInstance.AddCommand(moveUp);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                // MOVE DOWN
                moveDown = new MoveDownCommand(this.transform, _speed);
                moveDown.Execute();
                InputCommandManger.InputInstance.AddCommand(moveDown);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // MOVE Right
                moveRight = new MoveRightsCommand(this.transform, _speed);
                moveRight.Execute();
                InputCommandManger.InputInstance.AddCommand(moveRight);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                // MOVE Left
                moveLeft= new MoveLeftCommand(this.transform, _speed);
                moveLeft.Execute();
                InputCommandManger.InputInstance.AddCommand(moveLeft);
            }
        }
    }
}
