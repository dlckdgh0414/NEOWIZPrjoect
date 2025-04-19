using UnityEngine;

public class EnemyMover : MonoBehaviour
{

    [SerializeField] private Rigidbody _rbCompo;
    [SerializeField] private float speed;
    private Vector3 _moveDir = Vector3.zero;
    public bool CanMauanMove = true;


    public void SetDir(Transform targetDir)
    {
        _moveDir = targetDir.position - transform.position;
    }

    private void FixedUpdate()
    {
        if(CanMauanMove)
        {
            _rbCompo.linearVelocity = _moveDir.normalized * speed;
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

}
