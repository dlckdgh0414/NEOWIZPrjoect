using UnityEditorInternal;
using UnityEngine;

public class MousePlayerIdleState : MousePlayerCanMove
{
    public MousePlayerIdleState(Entity entity, int animationHash) : base(entity, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("MouseIdle");
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
