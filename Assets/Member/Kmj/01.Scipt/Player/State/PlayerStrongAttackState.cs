using UnityEngine;

public class PlayerStrongAttackState : PlayerState
{
    public PlayerStrongAttackState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (_isTriggerCall)
            _player.ChangeState("IDLE");
    }

    public override void Exit()
    {
        _player._isSkilling = false;
        base.Exit();
    }
}
