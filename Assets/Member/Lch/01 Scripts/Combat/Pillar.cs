using UnityEngine;

public class Pillar : MonoBehaviour,IDamgable
{
    [SerializeField] private Material colorMat;
    [SerializeField] private Pillar nearPillar;
    [SerializeField] private Pillar nearPillar2;
    [SerializeField] GameObject chain;
    [SerializeField] GameObject chain2;
    private MeshRenderer _pillerRenderer;
    private Material _beforMat;
    public bool IsOnPillar;

    public void ApplyDamage(float damage, bool isHit, int stunLevel, Entity delear)
    {
        IsOnPillar = true;
        _beforMat = _pillerRenderer.material;
        _pillerRenderer.material = colorMat;
        if (nearPillar.IsOnPillar)
        {
            chain.SetActive(true);
        }
        if (nearPillar2.IsOnPillar)
        {
            chain2.SetActive(true);
        }
    }

    public void OffPillar()
    {
        IsOnPillar = false;
        _pillerRenderer.material = _beforMat;
    }

    private void Awake()
    {
        _pillerRenderer = GetComponentInParent<MeshRenderer>();
    }
}
