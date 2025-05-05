using Member.Kmj._01.Scipt.Player.MousePlayer;
using UnityEngine;

public class MousePlayerStopState : EntityState
{
    private MousePlayer _player;
    public MousePlayerStopState(Entity entity, int animationHash) : base(entity, animationHash)
    {
        _player = entity as MousePlayer;    
    }

    public override void Enter()
    {
        _player._moveCompo.StopImmediately();
    }

    public override void Update()
    {
        base.Update();

        if (Vector3.Distance(_player.transform.position, _player.player.transform.position) >= 20)
        {
            _player._moveCompo.StopImmediately();
            _player._typeCompo.CurrentType = SoulType.Normal;
            _player.ChangeState("BACK");
            
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
