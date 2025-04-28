using UnityEngine;

public class PlayerFollowState : PlayerState
{

    private Vector3 _soulDir;

    public PlayerFollowState(Entity entity, int animationHash) : base(entity, animationHash)
    {
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
        _player.ChangeState("STRONGATTACK");
        base.Exit();
    }
}
