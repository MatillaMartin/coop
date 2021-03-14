using UnityEngine;

public class PickableResource : MonoBehaviour
{
    public PlayerResources playerResources;
    public Resource resource;

    public void OnPick(GameObject picker)
    {
        playerResources.Add(resource);
    }
}
