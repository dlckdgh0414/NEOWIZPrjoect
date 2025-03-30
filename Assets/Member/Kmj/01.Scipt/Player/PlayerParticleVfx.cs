using UnityEngine;

public class PlayParticleVfx : MonoBehaviour, IPlayableVfx
{
    [field: SerializeField] public string VfxName { get; private set; }
    [SerializeField] private bool isOnPostion;
    [SerializeField] private ParticleSystem particle;



    public void PlayVfx(Vector3 position, Quaternion rotation)
    {
        if (isOnPostion == false)
            transform.SetPositionAndRotation(position, rotation);

        particle.Play(withChildren: true);
    }

    public void StopVfx()
    {
        particle.Stop(withChildren: true);
    }

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(VfxName) == false)
            gameObject.name = VfxName;
    }
}
