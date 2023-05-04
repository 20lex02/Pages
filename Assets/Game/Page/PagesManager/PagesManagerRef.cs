using UnityEngine;

[CreateAssetMenu(fileName = "Pages Manager Ref", menuName = "Pages/Page Manager Ref")]
public class PagesManagerRef : ScriptableObject
{
    public void CollectPage(string pageText) => PagesManager.Instance.CollectPage(pageText);
}