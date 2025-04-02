using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class SkillPlayer : MonoBehaviour
{
    [SerializeField] private EntityAnimatorTrigger _trigger;

    [SerializeField] private LayerMask _whatIsEnemy;

    [SerializeField] private StatSO _skillAtkDamage;
    [SerializeField] private EntityStat _stat;

    private float StrongSkillDam;

    private void Awake()
    {
        _trigger.OnStrongAttackTrigger += StrongAttack;
        StrongSkillDam =_stat.GetStat(_skillAtkDamage).Value;
    }

    private void OnDestroy()
    {
        _trigger.OnStrongAttackTrigger -= StrongAttack;
    }


    private void StrongAttack()
    {
        RaycastHit hit;
        bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x * 0.5f, transform.forward,
            out hit, 3, _whatIsEnemy);

        Debug.Log(isHit);


        if (isHit)
        {
            Debug.Log(hit.transform.name);
            hit.transform.GetComponentInChildren<IDamgable>().ApplyDamage(StrongSkillDam
                , Vector2.zero, null);

        }
    }
}
