using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionRaycaster : MonoBehaviour
{
    public float InteractionMaxDistance;
    public Camera InteractionCamera;

    private Interactable _currentSelection;

    void FixedUpdate()
    {
        UpdateSelection();
    }

    public void OnInteract()
    {
        if (_currentSelection != null)
        {
            _currentSelection.Interact();
        }
    }

    void UpdateSelection()
    {
        var raycastRersults = Physics.RaycastAll(InteractionCamera.transform.position, InteractionCamera.transform.forward, InteractionMaxDistance);
        //print(string.Join(',',raycastRersults.Select(rs => rs.collider?.gameObject.ToString() ?? "NULL")));
        if (raycastRersults.Any() && raycastRersults.First().collider.gameObject.TryGetComponent<Interactable>(out var interactable))
        {
            if (_currentSelection != interactable)
            {
                _currentSelection?.Unfocus();
                _currentSelection = interactable;
                _currentSelection.Focus();
            }
        }
        else if (_currentSelection != null && raycastRersults.FirstOrDefault().collider?.gameObject.name != "Collider")
        {
            _currentSelection?.Unfocus();
            _currentSelection = null;
        }
    }
}
