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
        _energyCompo.StartFill();
        _energyCompo.StartFillMag();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
        _energyCompo.StopHeal();
        _energyCompo.StopMag();
    }
}
