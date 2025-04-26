using Unity.Behavior;
using UnityEngine;

public abstract class Enemy : Entity
{
    protected BehaviorGraphAgent btAgent;
    protected Rigidbody _rbCompo;
    [SerializeField] private float delectRange;
    [SerializeField] private float attackRange;

    [field: SerializeField] public EntityFinderSO PlayerFinder { get; protected set; }

    protected override void AfterInitialize()
    {
        base.AfterInitialize();
        btAgent = GetComponent<BehaviorGraphAgent>();
        Debug.Assert(btAgent != null, $"{gameObject.name} does not have an BehaviorGraphAgent");
        _rbCompo = GetComponent<Rigidbody>();
        Debug.Log("BT에너미 후 초기화");
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, delectRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
