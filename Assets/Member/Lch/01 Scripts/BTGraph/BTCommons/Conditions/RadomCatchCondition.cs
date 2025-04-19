using System;
using Unity.Behavior;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "RadomCatch", story: "Radom Catch to [RandValue]", category: "Conditions", id: "e2d7803c39825ce3918fdf1493bb9174")]
public partial class RadomCatchCondition : Condition
{
    [SerializeReference] public BlackboardVariable<float> RandValue;

    public override bool IsTrue()
    {
        float rand = Random.Range(1f, 100f);
        if(rand <= RandValue.Value)
        {
            return true;
        }
        return false;
    }
}
