using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MousePlayerAttackState : EntityState
{
    private MousePlayer _player;
    public MousePlayerAttackState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _player = entity as MousePlayer;
    }

    public override void Enter()
    {
        base.Enter();

        _player.rbCompo.AddForce(_entity.transform.forward * 12f, ForceMode.Impulse);
    }

    public override void Update()
    {
        base.Update();

        if (_isTriggerCall)
            _player.ChangeState("IDLE");
    }

    public override void Exit()
    {
        base.Exit();
    }
}
