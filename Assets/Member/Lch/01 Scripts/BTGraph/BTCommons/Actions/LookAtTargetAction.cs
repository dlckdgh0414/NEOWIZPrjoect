using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using static UnityEngine.EventSystems.EventTrigger;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "LookAtTarget", story: "[Self] to [Target] Look with [Renderer]", category: "Action", id: "455fd0bec1f521ca6bb87e82410e0f2e")]
public partial class LookAtTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<EnemyRenderer> Renderer;
    protected override Status OnStart()
    {
       
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if(Target.Value != null)
        {
            Vector3 dir = Target.Value.position;
            dir.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            Transform parent = Self.Value.transform;
            parent.rotation = Quaternion.Lerp(parent.rotation, targetRotation, Time.fixedDeltaTime * 8f);
        }
        
        return Status.Running;
    }
}

