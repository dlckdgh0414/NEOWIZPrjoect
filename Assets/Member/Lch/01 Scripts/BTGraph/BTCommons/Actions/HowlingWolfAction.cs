using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "HowlingWolf", story: "[Self] Spawn [HowlingAttack]", category: "Action", id: "6e9d81975391de7b07730cb02a5c01c3")]
public partial class HowlingWolfAction : Action
{
    [SerializeReference] public BlackboardVariable<Wolf> Self;
    [SerializeReference] public BlackboardVariable<WolfHollwingAttackCompo> HowlingAttack;
    private float _currentSpawnTime = 0f;
    private float _currentHowlingEndTime = 0f;
    private float _spawnTime = 0.3f;
    private float _howlingEnd = 7f;

    protected override Status OnStart()
    {
        Self.Value.OffPillar();
        HowlingAttack.Value.EnemyAttack(null, Self.Value);
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        _currentSpawnTime += Time.deltaTime;
        _currentHowlingEndTime += Time.deltaTime;
        if (_currentSpawnTime >= _spawnTime)
        {
           HowlingAttack.Value.FireFourWay();
            _currentSpawnTime = 0f;
        }
        if(_currentHowlingEndTime >= _howlingEnd)
        {
            _currentSpawnTime = 0f;
            return Status.Success;
        }
        return Status.Running;
    }
}

