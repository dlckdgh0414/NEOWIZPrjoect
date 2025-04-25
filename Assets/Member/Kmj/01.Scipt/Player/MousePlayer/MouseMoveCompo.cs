using UnityEngine;

public class MouseMoveCompo : MonoBehaviour, IEntityComponet
{
    [SerializeField] private StatSO moveSpeed;

    [SerializeField] private EntityStat statCompo;

    private float _moveSpeed;
    public void Initialize(Entity entity)
    {
        _moveSpeed = statCompo.GetStat(moveSpeed).Value;
    }

    /// <summary>
    /// Ÿ���� �������� �̵��ϴ� �ڵ�
    /// </summary>
    /// <param name="target"></param>
    public void MoveToAttackEntity(Transform target)
    {
        Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.fixedDeltaTime);
    }

    
}
