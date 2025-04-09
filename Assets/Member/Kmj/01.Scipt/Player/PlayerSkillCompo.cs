using System;
using System.Linq;
using UnityEngine;

public class PlayerSkillCompo : MonoBehaviour
{
    [SerializeField] private EntityAnimatorTrigger _trigger;

    [SerializeField] private LayerMask _whatIsEnemy;

    [SerializeField] private StatSO _strongAttackDamage;

    [SerializeField] private EntityStat _stat;

    [SerializeField] private Vector3 boxSize;
    [SerializeField] private Player _player;
 
    private float _strongDamage;
    private void Awake()
    {
        _trigger.OnStrongAttackTrigger += StrongAttack;
    }

    private void Start()
    {
        
        _strongDamage = _stat.GetStat(_strongAttackDamage).Value;
    }

    private void OnDestroy()
    {
        _trigger.OnStrongAttackTrigger -= StrongAttack;
    }

    private void StrongAttack()
    {
        Collider[] collider = Physics.OverlapBox(transform.position, boxSize,
            Quaternion.identity, _whatIsEnemy);

        collider.ToList().ForEach(x => x.GetComponentInChildren<IDamgable>().
        ApplyDamage(_strongDamage, false, _player));
    }
}
