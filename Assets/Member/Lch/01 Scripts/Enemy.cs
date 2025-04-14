using Unity.Behavior;
using UnityEngine;

public abstract class Enemy : Entity
{
    protected BehaviorGraphAgent btAgent;
    protected Rigidbody _rbCompo;

    [field: SerializeField] public EntityFinderSO PlayerFinder { get; protected set; }

    protected override void AfterInitialize()
    {
        base.AfterInitialize();
        btAgent = GetComponent<BehaviorGraphAgent>();
        Debug.Assert(btAgent != null, $"{gameObject.name} does not have an BehaviorGraphAgent");
        _rbCompo = GetComponent<Rigidbody>();
        Debug.Log("BT���ʹ� �� �ʱ�ȭ");
    }

    protected virtual void Start()
    {

    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        PlayerFinder.ClearSetTargets();
    }

    public BlackboardVariable<T> GetBlackboardVariable<T>(string key)
    {
        if (btAgent.GetVariable(key, out BlackboardVariable<T> result))
        {
            return result;
        }

        return default;
    }
}
