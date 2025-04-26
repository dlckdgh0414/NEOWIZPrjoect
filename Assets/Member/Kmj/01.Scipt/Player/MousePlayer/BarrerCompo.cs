using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BarrerCompo : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsBlockObj;

    [SerializeField] private MousePlayer _player;

    private Vector3 normal => this.GetComponentInChildren<Collision>().contacts[0].normal;

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if(_player._useSkillCompo.isPalling && ((1 << other.transform.gameObject.layer)
            & _whatIsBlockObj) != 0)
        {
            other.gameObject.GetComponent<SoulBullet>().ReflectDir(normal);
        }
        else if(((1 << other.transform.gameObject.layer) & _whatIsBlockObj ) != 0)
        {
            other.gameObject.SetActive(false);  
        }
    }
}
