using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "RayCastToTarget", story: "Check to [Target] in [CheckObj]", category: "Conditions", id: "b60b1bb55d625950b6b67b72d1d240e8")]
public partial class RayCastToTargetCondition : Condition
{
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<RayCastToTarget> CheckObj;
    public override bool IsTrue()
    {
       return CheckObj.Value.CheckToTargetRay(Target.Value);
    }

    public override void OnStart()
    {
    }

    public override void OnEnd()
    {
    }
}
