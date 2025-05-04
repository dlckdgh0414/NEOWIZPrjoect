using System.Reflection;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BarrerCompo : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsBlockObj;

    [SerializeField] private MousePlayer _player;

    public bool isPalling => _player._barrerSkill.isPalling;

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.transform.gameObject.layer) & _whatIsBlockObj) != 0 && isPalling)
        {
            Rigidbody rb = other.attachedRigidbody;

            other.TryGetComponent(out SoulBullet bullet);
            bullet._isReflect = true;
            
            if (rb != null)
            {
                Vector3 currentVelocity = rb.linearVelocity;
                
                Vector3 bounceDirection = - currentVelocity.normalized;
                float forceMagnitude = currentVelocity.magnitude;
                
                rb.AddForce(bounceDirection * forceMagnitude * 2f, ForceMode.VelocityChange);
            }
        }
        else if ((1 << other.transform.gameObject.layer & _whatIsBlockObj) != 0)
        {
            other.gameObject.SetActive(false);
        }
    }
}
