using UnityEngine;

public class MousePlayerSheldState : EntityState
{
    private MousePlayer _player;
    private MousePlayerEnergy _energyCompo;
    private MouseBarrerSkill _skillCompo;

    private float time;
    public MousePlayerSheldState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _player = entity as MousePlayer;
        _skillCompo = entity.GetComponentInChildren<MouseBarrerSkill>();
    }

    public override void Enter()
    {
        _player.isUseDashSkill = false;
        base.Enter();
        _player.LookAtMouse();
        time = 0;
        // _energyCompo.StartSkill(5);
        _player._barrerSkill.isPalling = true;
        _player.player.ChangeState("IDLE");
        _player.player._movement.StopImmediately();
    }

    public override void Update()
    {
        base.Update();

        time += Time.deltaTime;

        _player.transform.position = _player.player.transform.position;
        _player.player._movement.CanMove = false;

        if (time >= 10)
            _skillCompo.HandleBarrierCanceled();
        else if (time >= 0.8f)
            _player._barrerSkill.isPalling = false;

    }

    public override void Exit()
    {
        // _energyCompo.CancelSkill();
        _player._isSkilling = false;
        _player.player._movement.CanMove = true;
        base.Exit();
    }
}
