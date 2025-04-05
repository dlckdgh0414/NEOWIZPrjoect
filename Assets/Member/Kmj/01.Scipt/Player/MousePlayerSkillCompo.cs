using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MousePlayerSkillCompo : MonoBehaviour
{
    [SerializeField] private GameObject _barrierEffect;

    [SerializeField] private MousePlayerEnergy _energyCompo;

    [SerializeField] private EntityStat _stat;

    [SerializeField] private PlayerInputSO _trigger;
    [SerializeField] private Transform barrierTrans;
    [SerializeField] private MousePlayer _player;

    private bool _isSheld = false;
    public float BarrierHp { get; set; }

    private void Awake()
    {
        _trigger.OnSheldPressd += HandleBarrierPressed;
        _trigger.OnSheldCanceld += HandleBarrierCanceled;
    }

    private void OnDisable()
    {
        _trigger.OnSheldPressd -= HandleBarrierPressed;
        _trigger.OnSheldCanceld -= HandleBarrierCanceled;
    }

    private void Update()
    {
        Debug.Log(_energyCompo.energy);
        if (_isSheld)
            _energyCompo.UseEnergyTimeAtTime(5);
        else
            return;

    }

    private void HandleBarrierPressed()
    {
        if (_energyCompo.isEnergyNotzero && !_player._isSkilling)
        {
            _player.ChangeState("SHELD");
            _player._isSkilling = true;
            _isSheld = true;
            _barrierEffect.SetActive(true);
            _energyCompo.UseEnergy(10);
        }
        else
        {
            HandleBarrierCanceled();
        }
            
    }

    private void HandleBarrierCanceled()
    {
        _player.ChangeState("IDLE");
        _isSheld = false;
        _barrierEffect.SetActive(false);
    }
}
