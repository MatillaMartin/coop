using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public WeaponInventory inventory = null;
    public Weapon currentWeapon = null;
    public bool autoReload = true;

    // Start is called before the first frame update
    void Start()
    {
        if (inventory is null)
        {
            inventory = GetComponent<WeaponInventory>();
            Assert.IsNotNull(inventory, "GameObject must contain a WeaponInventory");
        }

        // start with first weapon
        SetCurrentWeapon(inventory.NextWeapon(currentWeapon));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnWeaponFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (currentWeapon)
            {
                // activate fire in current weapon
                if (currentWeapon.LoadedAmmo() > 0)
                {
                    Debug.Log("pew pew");
                    currentWeapon.Fire();

                    // automatic reload
                    if (autoReload)
                    {
                        if (currentWeapon.LoadedAmmo() == 0)
                        {
                            currentWeapon.Reload();
                        }
                    }
                }
            }
        }
    }

    public void OnWeaponChange(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var axis = context.ReadValue<float>();
            if (axis > 0)
            {
                Weapon weapon = inventory.NextWeapon(currentWeapon);
                SetCurrentWeapon(weapon);
                if (weapon is null)
                {
                    Debug.Log("No next weapon");
                }
            }
            else if (axis < 0)
            {
                Weapon weapon = inventory.PreviousWeapon(currentWeapon);
                SetCurrentWeapon(weapon);
                if (weapon is null)
                {
                    Debug.Log("No previous weapon");
                }
            }
        }
    }

    void SetCurrentWeapon(Weapon weapon)
    {
        // Check if the new weapon is different from the last weapon
        if (currentWeapon != weapon)
        {
            // If we already had a weapon, hide it
            if (currentWeapon)
            {
                currentWeapon.gameObject.SetActive(false);
            }

            // Set the new weapon in the correct position and show it. Mark as current
            weapon.gameObject.SetActive(true);
            currentWeapon = weapon;
        }
        else
        {
            Debug.Log("Weapon is already the current weapon");
        }
    }
}
