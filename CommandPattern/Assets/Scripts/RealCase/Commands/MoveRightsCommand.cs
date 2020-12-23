using RealCase.RCInterface;
using UnityEngine;

namespace RealCase.Commands
{
    public class MoveRightsCommand : IPlayerCommand
    {
        private Transform _player;
        private float _speed;


        public MoveRightsCommand(Transform player, float speed)
        {
            this._player = player;
            this._speed = speed;
        }

        public void Execute()
        {
            _player.Translate(Vector3.right * _speed * Time.deltaTime);
        }

        public void Undue()
        {
            _player.Translate(Vector3.left * _speed * Time.deltaTime);
        }
    }
}