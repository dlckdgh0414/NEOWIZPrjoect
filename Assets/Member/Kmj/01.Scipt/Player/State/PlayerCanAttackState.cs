using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.Playables;

public abstract class PlayerCanAttackState : PlayerState
{
    public PlayerCanAttackState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerInput.OnAttackPressd += HandleAttackPressed;
    }

    public override void Exit()
    {
        _player.PlayerInput.OnAttackPressd -= HandleAttackPressed;
        base.Exit();
    }

    private void HandleAttackPressed()
    {
        _player.ChangeState("ATTACK");
    }
}
