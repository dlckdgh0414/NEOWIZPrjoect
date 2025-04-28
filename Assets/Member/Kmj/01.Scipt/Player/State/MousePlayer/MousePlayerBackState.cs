using UnityEngine;

public class MousePlayerBackState : EntityState
{
    private MousePlayer _player;

    public MousePlayerBackState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _player = entity as MousePlayer;
    }

    public override void Enter()
    {
        _player.isUseDashSkill = true;
        base.Enter();
        Debug.Log("back");
        LookPlayer();
    }

    private void LookPlayer()
    {
        Vector3 direction = _player.player.transform.position - _player.transform.position;
        direction.y = 0;

        _player.transform.rotation = Quaternion.LookRotation(direction.normalized);
    }

    public override void Update()
    {
        base.Update();

        _player._moveCompo.MoveBack(_player.player.transform.position);


        if (Vector3.Distance(_player.player.transform.position,
            _player.transform.position) <= 1)
        {
            _player.ChangeState("IDLE");
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
