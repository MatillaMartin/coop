using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    public WeaponInventory m_inventory = null;
    public Weapon m_currentWeapon = null;

    // Start is called before the first frame update
    void Start()
    {
        if (m_inventory is null)
        {
            m_inventory = GetComponent<WeaponInventory>();
            Assert.IsNotNull(m_inventory, "GameObject must contain a WeaponInventory");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onWeaponChange(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Action was performed");
            var axis = context.ReadValue<float>();
            if (axis > 0)
            {
                Debug.Log("On Next weapon");
                Weapon weapon = m_inventory.NextWeapon(m_currentWeapon);
                SetCurrentWeapon(weapon);
                if (weapon is null)
                {
                    Debug.Log("No next weapon");
                }
            }
            else if (axis < 0)
            {
                Debug.Log("On Previous weapon");
                Weapon weapon = m_inventory.PreviousWeapon(m_currentWeapon);
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
        if (m_currentWeapon != weapon)
        {
            // If we already had a weapon, hide it
            if (m_currentWeapon)
            {
                m_currentWeapon.gameObject.SetActive(false);
            }

            // Set the new weapon in the correct position and show it. Mark as current
            weapon.gameObject.SetActive(true);
            m_currentWeapon = weapon;
        }
        else
        {
            Debug.Log("Weapon is already the current weapon");
        }
    }
}
