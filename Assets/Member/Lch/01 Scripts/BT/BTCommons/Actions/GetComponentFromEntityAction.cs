using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GetComponentFromEntity", story: "Get components from [btEnemy]", category: "Action", id: "7b26f18fcb48b2eacdd9324761fdf405")]
public partial class GetComponentFromEntityAction : Action
{
    [SerializeReference] public BlackboardVariable<BTEnemy> BtEnemy;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

