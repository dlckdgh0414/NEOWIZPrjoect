using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IsRushStop", story: "[Mover] to [isRushStop]", category: "Action", id: "dd328d0099399387f213b64ae1db1dfa")]
public partial class IsRushStopAction : Action
{
    [SerializeReference] public BlackboardVariable<EnemyMover> Mover;
    [SerializeReference] public BlackboardVariable<bool> IsRushStop;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (IsRushStop.Value)
        {
            Mover.Value.StopMover();
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

