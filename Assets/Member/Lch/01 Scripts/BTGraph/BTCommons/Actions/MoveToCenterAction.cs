using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveToCenter", story: "[Mover] to [Center]", category: "Action", id: "6a79034eebf019ece01888101ae04d5d")]
public partial class MoveToCenterAction : Action
{
    [SerializeReference] public BlackboardVariable<EnemyMover> Mover;
    [SerializeReference] public BlackboardVariable<Transform> Center;

    protected override Status OnStart()
    {
        Mover.Value.CanMauanMove =false;
        Mover.Value.SetDir(Center.Value);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(Mover.Value.IsArrived)
        {
            Mover.Value.StopMover();
            return Status.Success;
        }

        return Status.Running;
    }

    protected override void OnEnd()
    {
        Mover.Value.CanMauanMove=true;
        base.OnEnd();
    }
}

