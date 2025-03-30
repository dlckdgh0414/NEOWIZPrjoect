using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    private Entity _owner;
    [SerializeField] private LayerMask _whatIsEnemy;
    public void InitCaster(Entity owner)
    {
        _owner = owner;
    }

    public bool CastDamage(float damage, Vector2 knockback)
    {
        RaycastHit hit;
        bool isHit = Physics.SphereCast(transform.position,transform.lossyScale.x * 0.5f, transform.forward,
            out hit,0, _whatIsEnemy);
        Debug.Log(isHit);

        
        if(isHit && hit.transform != null)
        {
            Debug.Log(hit.transform.name);
            if(hit.transform.TryGetComponent(out IDamgable health))
            {
                health.ApplyDamage(damage, knockback);
            }
 
        }

        return isHit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, transform.lossyScale.x * 0.5f);
        Gizmos.color = Color.white;
    }
}
