using System.Collections.Generic;
using UnityEngine;
public class PlayerResources : MonoBehaviour
{
    public Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

    // Start is called before the first frame update
    void Start()
    {
        // intialize all resources with zero
        foreach (ResourceType resource in ResourceType.GetValues(typeof(ResourceType)))
        {
            resources.Add(resource, 0);
        }
    }

    /// <summary>
    ///  Adds a Resource to the PlayerResources
    /// </summary>
    /// <param name="resource">Resource to add</param>
    public void Add(Resource resource)
    {
        resources[resource.type] += resource.amount;

        foreach (KeyValuePair<ResourceType, int> pair in resources)
        {
            Debug.Log(pair.Key + " " + pair.Value);
        }
    }

    /// <summary>
    /// Checks if PlayerResources has enough of the given Resource amount
    /// </summary>
    /// <param name="resource">Resource and amount to check</param>
    /// <returns></returns>
    public bool Contains(Resource resource)
    {
        return resources[resource.type] >= resource.amount;
    }

    /// <summary>
    /// Removes given Resource from PlayerResources. If PlayerResource does not have enough, resources are not removed.
    /// </summary>
    /// <param name="resource">Resource and amount to remove</param>
    /// <returns>False if not enough resources, True if </returns>
    public bool Remove(Resource resource)
    {
        int leftOver = resources[resource.type] - resource.amount;
        if (leftOver < 0)
        {
            return false;
        }

        resources[resource.type] = leftOver;
        return true;
    }
}
