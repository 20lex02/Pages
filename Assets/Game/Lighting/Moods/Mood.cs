using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Mood", menuName = "Mood/Mood")]
public class Mood : ScriptableObject
{
    public float SkyboxExposure;
    public float SunIntensity;
    public Quaternion SunAngle;
    public float MusicVolume;
    public float WindVolume;
    public bool IsBlizzard;
    public bool IsSnowing;

    public float TransitionDuration;
}
