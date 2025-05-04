using UnityEngine;

namespace Member.Kmj._01.Scipt.Player.State.Player
{
    public class PlayerSwingAttackState : PlayerState
    {
        public PlayerSwingAttackState(Entity entity, int animationHash) : base(entity, animationHash)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            _player._soul.transform.position = _player._attackCompo.swingTrm.position;
            _player._soul.ChangeState("STOP");
            
            _player._soul.rbCompo.AddForce(Vector3.forward * 200f, ForceMode.Impulse);
            _player._movement.StopImmediately();
            _player._movement.CanMove = false;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}