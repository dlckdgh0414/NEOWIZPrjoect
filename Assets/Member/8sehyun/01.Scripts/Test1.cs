using UnityEngine;
using DG.Tweening;

public class Test1 : MonoBehaviour
{
    public Light pointLight;

    private void Start()
    {
        pointLight.intensity = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pointLight.DOIntensity(0, .6f).OnComplete(() => {
                pointLight.intensity = 5;
                pointLight.range = 20;
                pointLight.DOIntensity(0, .5f);
            });
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            pointLight.DOIntensity(0, .5f).OnComplete(() => {
                pointLight.intensity = 10;
                pointLight.range = 60;
                pointLight.DOIntensity(0f, 1f)
                .SetLoops(1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
            });
        }
    }
}
