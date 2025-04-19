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
    [SerializeReference] public BlackboardVariable<Enemy> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Soul;
    [SerializeReference] public BlackboardVariable<float> SpawnRange;
    private float _currentSpawnTime = 0f;
    private float _currentHowlingEndTime = 0f;
    private float _spawnTime = 0.3f;
    private float _howlingEnd = 7f;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        _currentSpawnTime += Time.deltaTime;
        _currentHowlingEndTime += Time.deltaTime;
        if (_currentSpawnTime >= _spawnTime)
        {
            GameObject.Instantiate(Soul,new Vector3(Random.Range(-10f,10f),0,Random.Range(-10f,10f)).normalized * SpawnRange,Quaternion.identity);
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

