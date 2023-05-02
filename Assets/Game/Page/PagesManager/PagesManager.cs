using System.Linq;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class PagesManager : MonoBehaviour
{
    #region Singleton
    private static PagesManager _instance;
    public static PagesManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var currentPagesManager = MonoBehaviour.FindObjectOfType<PagesManager>();
                if (currentPagesManager == null)
                {
                    Debug.LogError("Could not find PagesManager in scene. Does it exist?");
                }
                else
                {
                    _instance = currentPagesManager;
                }
            }
            return _instance;
        }
    }
    #endregion Singleton

    [Tooltip("Event called once the player collects the set number of pages")]
    [SerializeField] private List<CollectPageNumberEvent> _onCollectEvents;

    [ShowNonSerializedField] private int _pagesCollected;
    private Dictionary<int, UnityEvent[]> _onCollectEventsDict;

    void Start()
    {
        // Build a dictionnary from the object list for better access speed
        _onCollectEventsDict = _onCollectEvents
            .GroupBy(collectEvent => collectEvent.PageNumber)
            .ToDictionary(
                g => g.Key, 
                g => g.Select(collectEvent => collectEvent.OnCollect).ToArray()
            );
        
        foreach (var kp in _onCollectEventsDict)
        {
            print($"({kp.Key}, {kp.Value.Count()})");
        }
    }

    public void CollectPage(int id)
    {
        _pagesCollected++;

        if (_onCollectEventsDict.TryGetValue(_pagesCollected, out var events))
        {
            foreach (var collectEvent in events)
            {
                print("Invoking event");
                collectEvent.Invoke();
            }
        }


        print($"Collected Page {id}");
    }
}
