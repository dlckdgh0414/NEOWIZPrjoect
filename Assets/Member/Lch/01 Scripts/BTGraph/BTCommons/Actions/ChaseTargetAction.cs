using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ChaseTarget", story: "[Self] chase to [Target] with [Mover]", category: "Action", id: "830d76b996e5a91062300c8d7dd46bc6")]
public partial class ChaseTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<EnemyMover> Mover;

    protected override Status OnUpdate()
    {
        Mover.Value.SetDir(Target.Value);
        return Status.Success;
    }
}

