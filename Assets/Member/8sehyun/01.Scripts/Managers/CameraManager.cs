using UnityEngine;
using Unity.Cinemachine;
using Unity.Mathematics;
using System.Collections;
using Unity.VisualScripting;

public class CameraManager : MonoBehaviour
{
    private static CameraManager instance;

    public static CameraManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = new GameObject("CameraManager");
                instance = obj.AddComponent<CameraManager>();
                DontDestroyOnLoad(obj);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    //Variables
    private CinemachineCamera CinemachineCamera;
    private CinemachineBasicMultiChannelPerlin noise; //기본적으로 6D Shake를 사용함

    [Header("Default Shake Settings")]
    public float defaultShakeIntensity = 2f;
    public float defaultShakeDuration = 0.2f;

    private Coroutine shakeCoroutine;
    private bool isRunning = false;

    //Funcsions
    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        FindCinemachineCamera();
    }

    private void FindCinemachineCamera()
    {
        CinemachineCamera = FindFirstObjectByType<CinemachineCamera>();
        if (CinemachineCamera != null)
        {
            noise = CinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
        }
        else
        {
            noise = null;
        }
    }

    public void ShakeCamera(float intensity, float duration)
    {
        if (noise == null) return;
        if (isRunning) return;

        if (intensity < 0) intensity = defaultShakeIntensity;
        if (duration < 0) duration = defaultShakeDuration;

        if (shakeCoroutine != null)
            StopCoroutine(shakeCoroutine);

        shakeCoroutine = StartCoroutine(ShakeRoutine(intensity, duration));
    }

    private IEnumerator ShakeRoutine(float intensity, float duration)
    {
        noise.AmplitudeGain = intensity;
        isRunning = true;

        yield return new WaitForSeconds(duration / 3);

        float fadeOutTime = duration / 2;
        float elapsed = 0f;
        float startAmplitude = noise.AmplitudeGain;

        while (elapsed < fadeOutTime)
        {
            float t = elapsed / fadeOutTime;
            noise.AmplitudeGain = Mathf.Lerp(startAmplitude, 0f, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        noise.AmplitudeGain = 0f;
        isRunning = false;
    }
}
