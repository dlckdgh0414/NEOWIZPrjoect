using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] private Rigidbody _rbCompo;
    [SerializeField] private float speed;
    private Vector3 _moveDir = Vector3.zero;


    public void SetDir(Transform targetDir)
    {
        _moveDir = targetDir.position - transform.position;
    }

    private void FixedUpdate()
    {
        _rbCompo.linearVelocity = _moveDir * speed;
    }

    public void StopMover()
    {
        _moveDir = Vector3.zero;
    }

    public void BackStepEnemy(Transform target, float power,Transform enemy)
    {
         enemy.LookAt(target);
        _rbCompo.AddForce(Vector3.up * 1.5f);
        _rbCompo.AddForce(Vector3.back * power);
    }

}
