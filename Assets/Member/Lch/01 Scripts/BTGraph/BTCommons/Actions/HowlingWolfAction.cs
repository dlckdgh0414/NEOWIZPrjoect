using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Random = UnityEngine.Random;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "HowlingWolf", story: "[Self] Spawn [Soul] in [SpawnRange]", category: "Action", id: "6e9d81975391de7b07730cb02a5c01c3")]
public partial class HowlingWolfAction : Action
{
    [SerializeReference] public BlackboardVariable<Wolf> Self;
    [SerializeReference] public BlackboardVariable<float> SpawnRange;
    private float _currentSpawnTime = 0f;
    private float _currentHowlingEndTime = 0f;
    private float _spawnTime = 0.3f;
    private float _howlingEnd = 7f;

    protected override Status OnStart()
    {
        Self.Value.OffPillar();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        float xRange = Random.Range(-10f, 10f);
        float yRange = Random.Range(-10f, 10f);
        _currentSpawnTime += Time.deltaTime;
        _currentHowlingEndTime += Time.deltaTime;
        if (_currentSpawnTime >= _spawnTime)
        {
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

