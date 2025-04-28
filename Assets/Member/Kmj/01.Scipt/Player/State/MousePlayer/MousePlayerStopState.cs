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
    }

    public override void Exit()
    {
        base.Exit();
    }
}
