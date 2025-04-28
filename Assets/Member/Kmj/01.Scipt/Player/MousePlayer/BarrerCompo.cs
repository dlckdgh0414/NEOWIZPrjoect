using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BarrerCompo : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsBlockObj;

    [SerializeField] private MousePlayer _player;
    public bool isPalling => _player._useSkillCompo.isPalling;

    private void Update()
    {
        print(_player._useSkillCompo.isPalling);
    }
}
