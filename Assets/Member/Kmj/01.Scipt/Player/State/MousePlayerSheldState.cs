using UnityEngine;

public class MousePlayerSheldState : EntityState
{
    private MousePlayer _player;
    public MousePlayerSheldState(Entity entity, int animationHash) : base(entity, animationHash)
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
    }

    public override void Exit()
    {
        _player._isSkilling = false;
        base.Exit();
    }
}
