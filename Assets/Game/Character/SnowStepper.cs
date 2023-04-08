using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EnumExtensions;

public class SnowStepper : MonoBehaviour
{
    [SerializeField] private AudioSource _walkSource;
    [SerializeField] private AudioSource _runSource;

    public void UpdateSound(WalkState currentState)
    {
        _walkSource.mute = !currentState.IsBitSet(0);
        _runSource.mute = !currentState.IsBitSet(1);
    }
}