using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MousePlayerEnergySlider : MonoBehaviour
{
    [SerializeField] private MousePlayerEnergy _energyCompo;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI txt;
    private void Update()
    {
        _slider.value = _energyCompo.energy;

        txt.text = $"{(int)_energyCompo.energy}";
    }
}
