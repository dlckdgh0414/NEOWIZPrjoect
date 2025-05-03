using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Blade.Enemies;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IsRushStop", story: "is stop check to [WolfEnemy] in [Mover]", category: "Action", id: "dd328d0099399387f213b64ae1db1dfa")]
public partial class IsRushStopAction : Action
{
    [SerializeReference] public BlackboardVariable<Wolf> WolfEnemy;
    [SerializeReference] public BlackboardVariable<NavMovement> Mover;
    protected override Status OnStart()
    {
        Mover.Value.SetSpeedMultiply(2f);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (WolfEnemy.Value.IsRushStop)
        {
            Mover.Value.SetStop(true);
            Mover.Value.SetSpeedDivide(2);
            WolfEnemy.Value.IsRushStop = false;
            WolfEnemy.Value.IsRush = false;
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

