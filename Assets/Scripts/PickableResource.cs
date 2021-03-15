using UnityEngine;
using UnityEngine.Assertions;

public class PickableResource : MonoBehaviour, IPickable
{
    public Resource resource;

    public void OnPick(GameObject picker)
    {
        var playerResources = picker.GetComponent<PlayerResources>();
        Assert.IsNotNull(playerResources);
        if (playerResources)
        {
            // add resource to player resources
            playerResources.Add(resource);

            // remove pickable resource
            Destroy(gameObject);
        }
    }
}
