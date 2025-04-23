using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthGageAdjuster : MonoBehaviour
{
    [SerializeField] private EntityHealth _health;
    [SerializeField] private Image gage;

    private void Awake()
    {
        if (gage == null)
        {
            gage = GetComponent<Image>();
        }
    }

    public void ApplyHealth(float health)
    {
        float endHealth = health / _health.maxHealth;
        gage.DOFillAmount(endHealth, .5f);
    }
}