using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using DG.Tweening;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "ProdromalSymptoms", story: "[AttackMat] in [Self]", category: "Action", id: "03af3b97c2924197c233b18c1e04966b")]
public partial class ProdromalSymptomsAction : Action
{
    [SerializeReference] public BlackboardVariable<Material> AttackMat;
    [SerializeReference] public BlackboardVariable<Enemy> Self;
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    private Material _mat;

    protected override Status OnStart()
    {
        _skinnedMeshRenderer = Self.Value.GetComponentInChildren<SkinnedMeshRenderer>();
        _mat = _skinnedMeshRenderer.material;
        _skinnedMeshRenderer.material = AttackMat;
        DOVirtual.DelayedCall(0.25f, () => _skinnedMeshRenderer.material = _mat);
        return Status.Success;
    }
}

