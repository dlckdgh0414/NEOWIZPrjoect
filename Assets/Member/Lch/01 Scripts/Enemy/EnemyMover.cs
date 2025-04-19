using UnityEngine;

public class EnemyMover : MonoBehaviour,IEntityComponet
{

    [SerializeField] private Rigidbody _rbCompo;
    [field: SerializeField] public float Speed { get; set; }
    private Vector3 _moveDir = Vector3.zero;
    public bool CanMauanMove = true;
    private Vector3 _destination;
    [SerializeField] private float stopThreshold = 0.8f;
    public bool IsArrived => Vector3.Distance(_entity.transform.position, _moveDir) < stopThreshold;
    private Entity _entity;


    public void SetDir(Transform targetDir)
    {
        _moveDir = targetDir.position - transform.position;
        _moveDir.y = 0;
        _moveDir.Normalize();
    }

    public void RushDir(Transform targetDir)
    {
        _moveDir = targetDir.forward;
        _moveDir.y = 0;
        _moveDir.Normalize();
    }

    private void FixedUpdate()
    {
        if(CanMauanMove)
        {
            _rbCompo.linearVelocity = _moveDir * Speed;
        }
        else
        {
            _rbCompo.MovePosition(_entity.transform.position + _moveDir *(Speed *Time.fixedDeltaTime));
        }
    }

    public void StopMover()
    {
        _moveDir = Vector3.zero;
    }

    public void BackStepEnemy(Transform target, float power,Transform enemy)
    {
         enemy.LookAt(target);
        _rbCompo.AddForce(Vector3.up * 1.5f, ForceMode.Impulse);

        _rbCompo.AddForce(-enemy.forward * power, ForceMode.Impulse);
        Debug.Log("È÷ÆR");
    }

    public void Initialize(Entity entity)
    {
        _entity = entity;
    }
}
