using Blade.Enemies;
using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "PATROL", story: "[Self] patrol with [WayPoints]", category: "Action", id: "52634db1c99ef64a3de91eed01a0eb07")]
public partial class PatrolAction : Action
{
    [SerializeReference] public BlackboardVariable<Enemy> Self;
    [SerializeReference] public BlackboardVariable<WayPoints> WayPoints;

    private int _currentPointIdx;
    private NavMovement _navMovement;

    protected override Status OnStart()
    {
        Iniitialze();
        _navMovement.SetDestination(WayPoints.Value[_currentPointIdx].position);
        return Status.Running;
    }

    private void Iniitialze()
    {
        if(_navMovement == null)
            _navMovement = Self.Value.GetCompo<NavMovement>();
    }

    protected override Status OnUpdate()
    {
        if (_navMovement.IsArrived)
        {
            return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
        _currentPointIdx = (_currentPointIdx +1) % WayPoints.Value.Length;
    }
}

