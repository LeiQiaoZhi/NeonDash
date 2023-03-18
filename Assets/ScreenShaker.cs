using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Cinemachine;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    [Header("Default Settings")] public float shakeDuration = 0.3f;
    public float shakeAmplitude = 1.2f;
    public float shakeFrequency = 2.0f;

    public static ScreenShaker Instance;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin noise =
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = shakeAmplitude;
        noise.m_FrequencyGain = shakeFrequency;
        Invoke("StopShaking", shakeDuration);
    }

    public void ShakeCamera(float amplitude, float frequency, float duration)
    {
        CinemachineBasicMultiChannelPerlin noise =
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;
        Invoke("StopShaking", duration);
    }

    void StopShaking()
    {
        CinemachineBasicMultiChannelPerlin noise =
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
    }
}