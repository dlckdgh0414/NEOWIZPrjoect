using UnityEngine;

public class RayCastToTarget : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private LayerMask whatIsObj;

    public bool CheckToTargetRay(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target.position);

        if (Physics.Raycast(transform.position, direction, distance,whatIsPlayer)&& !Physics.Raycast(transform.position, direction, distance,whatIsObj))
        {
            Debug.Log("¾Ó±â¸ð¶ì");
            return true;
        }


        return false;
    }
}
