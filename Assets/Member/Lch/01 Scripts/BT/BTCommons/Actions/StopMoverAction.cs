using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "StopMover", story: "[Mover] is Stop", category: "Action", id: "7bd289c4b7c90f115a225eeec9a04902")]
public partial class StopMoverAction : Action
{
    [SerializeReference] public BlackboardVariable<EnemyMover> Mover;

    protected override Status OnStart()
    {
        Mover.Value.StopMover();    
        return Status.Success;
    }
}

