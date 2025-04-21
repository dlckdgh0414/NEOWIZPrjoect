using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IsRushStop", story: "is stop check to [WolfEnemy] in [Mover]", category: "Action", id: "dd328d0099399387f213b64ae1db1dfa")]
public partial class IsRushStopAction : Action
{
    [SerializeReference] public BlackboardVariable<Wolf> WolfEnemy;
    [SerializeReference] public BlackboardVariable<EnemyMover> Mover;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (WolfEnemy.Value.IsRushStop)
        {
            Mover.Value.StopMover();
            Mover.Value.Speed /= 2f;
            WolfEnemy.Value.IsRushStop = false;
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

