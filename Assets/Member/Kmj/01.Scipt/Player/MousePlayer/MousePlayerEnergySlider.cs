using UnityEngine;
using UnityEngine.UI;

public class MousePlayerEnergySlider : MonoBehaviour
{
    [SerializeField] private MousePlayerEnergy _energyCompo;
    [SerializeField] private Slider _slider;
    private void Update()
    {
        _slider.value = _energyCompo.energy;
    }
}
