using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class PageHUD : MonoBehaviour
{
    #region Singleton
    private static PageHUD _instance;
    public static PageHUD Instance
    {
        get
        {
            if (_instance == null)
            {
                var currentPageHUD = MonoBehaviour.FindObjectOfType<PageHUD>();
                if (currentPageHUD == null)
                {
                    Debug.LogError("Could not find PagesHUD in scene. Does it exist?");
                }
                else
                {
                    _instance = currentPageHUD;
                }
            }
            return _instance;
        }
    }
    #endregion Singleton

    public UnityEvent OnDismiss;

    [SerializeField] private TMP_Text _text;
    private CanvasGroup _canvasGroup;

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ShowPage(string message)
    {
        _canvasGroup.alpha = 1;
        _text.text = message;
    }

    public void DismissPage()
    {
        _canvasGroup.alpha = 0;
    }
}
