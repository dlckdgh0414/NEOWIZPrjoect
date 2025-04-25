using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MousePlayerAttackState : EntityState
{
    private MousePlayer _player;
    private Vector3 _attackPosition;
    public MousePlayerAttackState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _player = entity as MousePlayer;
    }

    public override void Enter()
    {
        base.Enter();

       

    }

    public override void Update()
    {
        base.Update();
        
        //Vector3.MoveTowards(_entity.transform.position, _attackPosition,)

        if (_isTriggerCall)
            _player.ChangeState("IDLE");
    }

    public override void Exit()
    {
        base.Exit();
    }
}
