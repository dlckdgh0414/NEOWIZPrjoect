using Member.Kmj._01.Scipt.Player.MousePlayer;
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
            
            

            _player._soul._typeCompo.CurrentType = AttriType.Fire;
            _player._soul.transform.position = _player._attackCompo.swingTrm.position;
            _player._soul.ChangeState("STOP");
            
            
        }

        public override void Update()
        {
            
            if (_isTriggerCall)
            {
                _player.ChangeState("IDLE");
            }
            
            base.Update();
        }

        public override void Exit()
        {
            _player._movement.CanMove = true;
            
            base.Exit();
            
        }
    }
}