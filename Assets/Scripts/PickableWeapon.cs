using UnityEngine;

public class PickableWeapon : MonoBehaviour, IPickable
{
    public Weapon weapon;

    public void OnPick(GameObject picker)
    {
        var inventory = picker.GetComponent<WeaponInventory>();
        inventory.Add(weapon);
    }
}
