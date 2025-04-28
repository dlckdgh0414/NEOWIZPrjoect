using UnityEngine;

public class PlayerFollowState : PlayerState
{

    private Vector3 _soulDir;

    public PlayerFollowState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        _player.isDoingFollow = true;
        _player._soul.ChangeState("STOP");

        _soulDir = _player._soul.transform.position;
        _player._movement.LookAt(_soulDir);
        base.Enter();
    }

    public override void Update()
    {

        _player._movement.MoveToEntity(_soulDir);

        if(Vector3.Distance(_player.transform.position, _soulDir) <= 1.25f)
        {
            _player.ChangeState("STRONGATTACK");
            _player._soul.ChangeState("IDLE");
        }
        base.Update();
    }

    public override void Exit()
    {
        _player.isDoingFollow = false;
        base.Exit();
    }
}
