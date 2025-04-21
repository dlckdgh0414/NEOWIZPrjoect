using UnityEngine;

public class Pillar : MonoBehaviour,IDamgable
{
    [SerializeField] private Material colorMat;
    [SerializeField] private Pillar nearPillar;
    [SerializeField] GameObject chain;
    private MeshRenderer _pillerRenderer;
    public bool IsOnPillar;

    public void ApplyDamage(float damage, bool isHit, int stunLevel, Entity delear)
    {
        IsOnPillar = true;
        _pillerRenderer.material = colorMat;
        if (nearPillar.IsOnPillar)
        {
            chain.SetActive(true);
        }
    }

    private void Awake()
    {
        _pillerRenderer = GetComponent<MeshRenderer>();
    }
}
