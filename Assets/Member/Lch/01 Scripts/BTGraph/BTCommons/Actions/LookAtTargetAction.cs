using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "LookAtTarget", story: "[Self] to [Target] Look with [Renderer]", category: "Action", id: "455fd0bec1f521ca6bb87e82410e0f2e")]
public partial class LookAtTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<EnemyRenderer> Renderer;
    protected override Status OnStart()
    {
        Renderer.Value.LoockAtPlayer(Target.Value,Self.Value);
        return Status.Success;
    }
}

