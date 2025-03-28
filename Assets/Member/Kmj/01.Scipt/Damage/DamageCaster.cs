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
        Debug.Log("ÀÏ´Ü ³Í ¾Æ´Ô");
        RaycastHit hit;
        Debug.Log("³Êµµ ¾Æ´Ô");
        bool isHit = Physics.SphereCast(transform.position,transform.lossyScale.x * 0.5f, transform.forward,
            out hit,3, _whatIsEnemy);

        Debug.Log("³Ê±îÁø?");
        Debug.Log(isHit);

        
        if(isHit && hit.transform != null)
        {
            Debug.Log("³Î ¾Æ´Ô");
            Debug.Log(hit.transform.name);
            if(hit.transform.TryGetComponent(out EntityHealth health))
            {
                health.ApplyDamage(damage, knockback);
            }
 
        }
          Debug.Log("³Ê±¸³ª");

        return isHit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, transform.lossyScale.x * 0.5f);
        Gizmos.color = Color.white;
    }
}
