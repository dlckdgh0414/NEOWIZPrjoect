using UnityEngine;

public class EnemyRenderer : MonoBehaviour
{
    [SerializeField]private Wolf wolf;
    public Transform target;
    private void FixedUpdate()
    {
        if(target!= null)
        {
            LoockAtPlayer(target, wolf.gameObject);
        }
        
    }

    public void LoockAtPlayer(Transform target,GameObject enemy)
    {
        Vector3 dir = target.position;
        dir.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        Transform parent = enemy.transform;
        parent.rotation = Quaternion.Lerp(parent.rotation, targetRotation, Time.fixedDeltaTime * 8f);
    }
}
