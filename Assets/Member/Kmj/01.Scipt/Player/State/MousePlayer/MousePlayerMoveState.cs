using UnityEngine;

public class MousePlayerMoveState : MousePlayerCanMove
{

    private Vector3 dir = Vector3.zero;

    private MousePlayerEnergy _energyCompo;
    private MousePlayerSkillCompo _skillCompo;
    public MousePlayerMoveState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _energyCompo = _entity.GetComponentInChildren<MousePlayerEnergy>();
        _skillCompo = entity.GetComponentInChildren<MousePlayerSkillCompo>();
    }

    public override void Enter()
    {
        base.Enter();

        _player.rbCompo.linearVelocity = Vector3.zero;

        dir = _player.MoveToMousePosition(_player);

        _energyCompo.UseEnergy(15);

        _energyCompo.StartSkill(0.2f);

        if (_energyCompo.energy <= 0)
        {
            _player.ChangeState("IDLE");
        }
        _player.LookAtMouse();

    }

    public override void Update()
    {
        base.Update();
        
        _player.transform.position = Vector3.MoveTowards(_player.transform.position,
            dir, 10f * Time.deltaTime);

        if(_energyCompo.energy <= 0)
        {
            _player.ChangeState("IDLE");
        }

        

        if (_player.transform.position == dir)
        {
            _player.ChangeState("IDLE");
        }

    }

    public override void Exit()
    {
        _energyCompo.CancelSkill();
        base.Exit();
    }
}
