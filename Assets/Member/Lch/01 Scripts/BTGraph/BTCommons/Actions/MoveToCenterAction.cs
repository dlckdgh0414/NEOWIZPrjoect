using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Blade.Enemies;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveToCenter", story: "[Mover] to [Center]", category: "Action", id: "6a79034eebf019ece01888101ae04d5d")]
public partial class MoveToCenterAction : Action
{
    [SerializeReference] public BlackboardVariable<NavMovement> Mover;
    [SerializeReference] public BlackboardVariable<Transform> Center;

    protected override Status OnStart()
    {
        Mover.Value.SetDestination(Center.Value.position);
        Mover.Value.SetSpeedMultiply(3f);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(Mover.Value.IsArrived)
        {
            Mover.Value.SetStop(true);
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
        Mover.Value.SetSpeedDivide(3);
        base.OnEnd();
    }
}

