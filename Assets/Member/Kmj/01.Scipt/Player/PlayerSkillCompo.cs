using System;
using UnityEngine;

public class PlayerSkillCompo : MonoBehaviour
{
    [SerializeField] private EntityAnimatorTrigger _trigger;

    [SerializeField] private LayerMask _whatIsEnemy;

    [SerializeField] private StatSO _strongAttackDamage;

    [SerializeField] private EntityStat _stat;

    private float _strongDamage;
    private void Awake()
    {
        _trigger.OnStrongAttackTrigger += StrongAttack;
    }

    private void Start()
    {
        
        _strongDamage = _stat.GetStat(_strongAttackDamage).Value;
    }

    private void StrongAttack()
    {
        RaycastHit hit;

        bool ishit = Physics.SphereCast(transform.position, transform.lossyScale.x * 0.5f, transform.forward,
            out hit, 3, _whatIsEnemy);

        if(ishit)
        {
            if(hit.transform.TryGetComponent(out IDamgable damage))
            {
                damage.ApplyDamage(_strongDamage, Vector2.zero, null);
            }
        }
    }
}
