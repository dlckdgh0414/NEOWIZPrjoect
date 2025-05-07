using UnityEngine;

public class MouseMoveCompo : MonoBehaviour, IEntityComponet
{
    [SerializeField] private StatSO moveSpeed;
    [SerializeField] private StatSO backMoveSpeed;

    [SerializeField] private EntityStat statCompo;

    private float _moveSpeed;
    private float _backMoveSpeed;

    private MousePlayer _mousePlayer;
    public void Initialize(Entity entity)
    {
        _mousePlayer = entity as MousePlayer;
        _moveSpeed = statCompo.GetStat(moveSpeed).Value;
        _backMoveSpeed = statCompo.GetStat(backMoveSpeed).Value;
    }

    /// <summary>
    /// Ÿ���� �������� �̵��ϴ� �ڵ�
    /// </summary>
    /// <param name="target"></param>
    public void MoveToAttackEntity(Vector3 target)
    {
       _mousePlayer.transform.position =
            Vector3.MoveTowards(_mousePlayer.transform.position, target, _moveSpeed * Time.deltaTime);
    }

    public void MoveBack(Vector3 target)
    {
        _mousePlayer.transform.position =
             Vector3.MoveTowards(_mousePlayer.transform.position, target, _backMoveSpeed * Time.deltaTime);
    }
    public void StopImmediately()
    {
        _mousePlayer.GetComponentInChildren<Rigidbody>().linearVelocity = Vector3.zero;
    }


}
