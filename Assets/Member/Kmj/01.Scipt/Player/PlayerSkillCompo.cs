using System;
using UnityEngine;

public class PlayerSkillCompo : MonoBehaviour
{
    [SerializeField] private EntityAnimatorTrigger _trigger;

    [SerializeField] private LayerMask _whatIsEnemy;

    [SerializeField] private StatSO _strongAttackDamage;

    [SerializeField] private EntityStat _stat;

    [SerializeField] private Vector3 boxSize;

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

        bool ishit = Physics.BoxCast(transform.position, boxSize,transform.position, out hit,
            Quaternion.identity, 8, _whatIsEnemy);

        if(ishit)
        {
            if(hit.transform.TryGetComponent(out IDamgable damage))
            {
                damage.ApplyDamage(_strongDamage, Vector2.zero, null);
            }
        }
    }
}
