using UnityEngine;

public class EnemyRenderer : MonoBehaviour
{
    public void LoockAtPlayer(Transform target,GameObject enemy)
    {
        
        enemy.transform.LookAt(target);
    }
}
