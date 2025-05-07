using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Blade.Enemies;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "IsRushStop", story: "is stop check to [WolfEnemy] in [Mover] with [Target]", category: "Action", id: "dd328d0099399387f213b64ae1db1dfa")]
public partial class IsRushStopAction : Action
{
    [SerializeReference] public BlackboardVariable<Wolf> WolfEnemy;
    [SerializeReference] public BlackboardVariable<NavMovement> Mover;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    protected override Status OnStart()
    {
        WolfEnemy.Value.IsRush = true;
        Mover.Value.SetSpeedMultiply(2f);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (WolfEnemy.Value.IsRushStop)
        {
            Mover.Value.SetStop(true);
            Mover.Value.agent.enabled = false;
            Mover.Value.SetSpeedDivide(2);
            WolfEnemy.Value.IsRush = false;
            WolfEnemy.Value.IsRushStop = false;
            return Status.Success;
        }
        Mover.Value.SetDestination(Target.Value.position);

        return Status.Running;
    }

    protected override void OnEnd()
    {
        Mover.Value.agent.enabled = true;
    }
}

