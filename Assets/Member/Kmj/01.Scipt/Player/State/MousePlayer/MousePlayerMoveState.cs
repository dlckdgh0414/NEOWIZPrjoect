using UnityEngine;

public class MousePlayerMoveState : MousePlayerCanAttack
{

    private Vector3 dir = Vector3.zero;

    private MousePlayerSkillCompo _skillCompo;
    public MousePlayerMoveState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _player.rbCompo.linearVelocity = Vector3.zero;

        dir = _player.PlayerInput.GetWorldPosition(out RaycastHit hit);

        _player.LookAtMouse();

    }

    public override void Update()
    {
        base.Update();

        _player._moveCompo.MoveToAttackEntity(dir);

        

        if (Vector3.Distance(_player.transform.position, dir) <= 1)
        {
            _player.ChangeState("ATTACK");
        }

    }

    public override void Exit()
    {
        // _energyCompo.CancelSkill();
        _player._moveCompo.StopImmediately();
        base.Exit();
    }
}
