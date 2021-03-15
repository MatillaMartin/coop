using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickingController : MonoBehaviour
{
    public GameObject picker;

    public List<Collider> pickables;
    public Collider currentPickable;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger enter");
        if (!pickables.Contains(other))
        {
            pickables.Add(other);
            updateClosestPickable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exit");
        if (pickables.Contains(other))
        {
            pickables.Remove(other);
            updateClosestPickable();
        }
    }

    void updateClosestPickable()
    {
        Collider closest = null;
        float closestDistance = float.MaxValue;
        foreach (Collider collider in pickables)
        {
            float distance = Vector3.Distance(picker.transform.position, collider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = collider;
            }
        }

        currentPickable = closest;
    }

    public void OnPick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("On pick called");
            if (currentPickable == null) return;

            IPickable p = currentPickable.gameObject.GetComponent<IPickable>();
            if (p != null)
            {
                Debug.Log("Picking up pickable");
                p.OnPick(picker);
                pickables.Remove(currentPickable);
            }
        }
    }
}
