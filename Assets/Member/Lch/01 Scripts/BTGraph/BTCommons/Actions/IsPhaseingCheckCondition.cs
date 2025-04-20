using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "IsPhaseingCheck", story: "Phase is [Start]", category: "Conditions", id: "d456e1595ec488717ea4e6dde7acfbfe")]
public partial class IsPhaseingCheckCondition : Condition
{
    [SerializeReference] public BlackboardVariable<bool> Start;

    public override bool IsTrue()
    {
        if(Start)
        {
            return true;
        }

        return false;
    }
}
