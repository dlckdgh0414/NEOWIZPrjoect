using UnityEngine;

public class MousePlayerSheldState : EntityState
{
    public MousePlayerSheldState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("½¯µåµÊ");
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
