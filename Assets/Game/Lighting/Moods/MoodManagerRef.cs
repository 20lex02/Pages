using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoodManager Ref", menuName = "Mood/Mood Manager Ref")]
public class MoodManagerRef : ScriptableObject
{
    public void SetMood(Mood mood) => MoodManager.Instance.SetMood(mood);
}
