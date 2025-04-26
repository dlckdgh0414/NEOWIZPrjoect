using UnityEngine;

public class MousePlayerSheldState : EntityState
{
    private MousePlayer _player;
    private MousePlayerEnergy _energyCompo;
    private MousePlayerSkillCompo _skillCompo;
    public MousePlayerSheldState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _player = entity as MousePlayer;
        _skillCompo = entity.GetComponentInChildren<MousePlayerSkillCompo>();
    }

    public override void Enter()
    {
        base.Enter();
        _player.LookAtMouse();
        // _energyCompo.StartSkill(5);
        _player.player.ChangeState("IDLE");
        _player.transform.position = _player.player.transform.position;
        _player.player._movement.StopImmediately();
        Debug.Log("½¯µå");
    }

    public override void Update()
    {
        base.Update();

        float time = 0;
        time += Time.deltaTime;

        _player.player._movement.CanMove = false;

        if (time >= 10)
            _skillCompo.HandleBarrierCanceled();
    }

    public override void Exit()
    {
        // _energyCompo.CancelSkill();
        _player._isSkilling = false;
        _player.player._movement.CanMove = true;
        base.Exit();
    }
}
