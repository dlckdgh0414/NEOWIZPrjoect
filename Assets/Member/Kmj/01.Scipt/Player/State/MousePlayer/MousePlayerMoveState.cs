using UnityEngine;

public class MousePlayerMoveState : MousePlayerCanAttack
{

    private Vector3 dir = Vector3.zero;

    private MousePlayerEnergy _energyCompo;
    private MousePlayerSkillCompo _skillCompo;
    public MousePlayerMoveState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _player.rbCompo.linearVelocity = Vector3.zero;

        dir = _player.MoveToMousePosition(_player);

        _player.LookAtMouse();

    }

    public override void Update()
    {
        base.Update();
        
        _player.transform.position = Vector3.MoveTowards(_player.transform.position,
            dir, 25f * Time.deltaTime);

        

        if (_player.transform.position == dir)
        {
            _player.ChangeState("IDLE");
        }

    }

    public override void Exit()
    {
       // _energyCompo.CancelSkill();
        base.Exit();
    }
}
