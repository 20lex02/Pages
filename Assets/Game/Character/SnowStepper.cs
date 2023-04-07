using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EnumExtensions;

public class SnowStepper : MonoBehaviour
{
    public float EnabledVolume = 1;
    [SerializeField] private AudioSource _walkSource;
    [SerializeField] private AudioSource _runSource;

    public void UpdateSound(WalkState currentState)
    {
        _walkSource.volume = currentState.IsBitSet(0) ? 0 : EnabledVolume;
        _runSource.volume = currentState.IsBitSet(1) ? 0 : EnabledVolume;
    }
}