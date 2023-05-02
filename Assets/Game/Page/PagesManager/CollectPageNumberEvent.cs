using UnityEngine.Events;

[System.Serializable]
public struct CollectPageNumberEvent
{
    public int PageNumber;
    public UnityEvent OnCollect;
}