using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent OnInteract;
    public UnityEvent OnFocus;
    public UnityEvent OnUnfocus;
    public bool DestroyOnInteract;
    
    public void Focus()
    {
        print("Focus");
        OnFocus.Invoke();
    }

    public void Unfocus()
    {
        print("Unfocus");
        OnUnfocus.Invoke();
    }

    public void Interact()
    {
        OnInteract.Invoke();
        if (DestroyOnInteract) 
            Destroy(gameObject);
    }
}
