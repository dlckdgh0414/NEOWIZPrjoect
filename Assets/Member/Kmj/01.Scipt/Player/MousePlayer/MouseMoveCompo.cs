using UnityEngine;

public class MouseMoveCompo : MonoBehaviour, IEntityComponet
{
    [SerializeField] private StatSO moveSpeed;

    [SerializeField] private EntityStat statCompo;

    private float _moveSpeed;

    private MousePlayer _mousePlayer;
    public void Initialize(Entity entity)
    {
        _mousePlayer = entity as MousePlayer;
        _moveSpeed = statCompo.GetStat(moveSpeed).Value;
    }

    /// <summary>
    /// 타겟의 방향으로 이동하는 코드
    /// </summary>
    /// <param name="target"></param>
    public void MoveToAttackEntity(Vector3 target)
    {
       _mousePlayer.transform.position =
            Vector3.MoveTowards(_mousePlayer.transform.position, target, _moveSpeed * Time.deltaTime);
    }
    public void StopImmediately()
    {
        _mousePlayer.GetComponentInChildren<Rigidbody>().linearVelocity = Vector3.zero;
    }


}
