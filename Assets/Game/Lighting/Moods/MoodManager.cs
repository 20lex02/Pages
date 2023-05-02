using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

public class MoodManager : MonoBehaviour
{

    #region Singleton
    private static MoodManager _instance;
    public static MoodManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var currentMoodManager = MonoBehaviour.FindObjectOfType<MoodManager>();
                if (currentMoodManager == null)
                {
                    Debug.LogError("Could not find MoodManager in scene. Does it exist?");
                }
                else
                {
                    _instance = currentMoodManager;
                }
            }
            return _instance;
        }
    }
    #endregion Singleton

    public ParticleSystem BlizzardParticle;
    public ParticleSystem SnowParticle;
    public AudioSource MusicSource;
    public AudioSource WindSource;
    

    [SerializeField] private Mood _initialMood;
    [ShowNonSerializedField] private Mood _currentMood;
    
    void Start()
    {
        if (_initialMood != null) SetMood(_initialMood);
    }

    public void SetMood(Mood mood)
    {
        _currentMood = mood;

        DoSkyboxFade(mood.SkyboxExposure, mood.TransitionDuration);
        RenderSettings.sun.transform.DORotate(mood.SunAngle.eulerAngles, mood.TransitionDuration);
        RenderSettings.sun.DOIntensity(mood.SunIntensity, mood.TransitionDuration);

        if (mood.IsBlizzard)
        {
            if (!BlizzardParticle.isPlaying) BlizzardParticle.Play();
        }
        else
        {
            BlizzardParticle.Stop();
        }

        if (mood.IsSnowing)
        {
            if (!SnowParticle.isPlaying) SnowParticle.Play();
        }
        else
        {
            SnowParticle.Stop();
        }

        MusicSource.DOFade(mood.MusicVolume, mood.TransitionDuration);
        WindSource.DOFade(mood.WindVolume, mood.TransitionDuration);
    }

    private void DoSkyboxFade(float newExposure, float duration)
    {
        DOTween.To(
            () => RenderSettings.skybox.GetFloat("_Exposure"), 
            val => RenderSettings.skybox.SetFloat("_Exposure", val), 
            newExposure, 
            duration
        );
    }
}
