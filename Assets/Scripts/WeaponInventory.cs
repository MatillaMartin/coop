using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    // Current list of weapons in the inventory
    public List<Weapon> m_weapons;

    // Where to hold the weapon
    public Transform m_weaponTransform;

    // Start is called before the first frame update
    void Start()
    {
        // hide all weapons if any
        foreach (Weapon weapon in m_weapons)
        {
            weapon.gameObject.SetActive(false);
            weapon.gameObject.transform.SetParent(m_weaponTransform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Add(Weapon weapon)
    {
        if (m_weapons.Contains(weapon))
        {
            Weapon(weapon.type).AddAmmo(weapon.TotalAmmo());
        }
        else
        {
            // Instantiate Weapon from prefab
            Weapon instance = Instantiate(weapon, m_weaponTransform);
            // Hide until selected
            instance.gameObject.SetActive(false);
            // Add to weapons list
            m_weapons.Add(weapon);
        }
    }

    public bool Contains(Weapon weapon)
    {
        return m_weapons.Contains(weapon);
    }

    public Weapon Weapon(WeaponType type)
    {
        Weapon weapon = m_weapons.Find(x => x.type == type);
        if (!weapon)
        {
            Debug.Log("WeaponInventory does not contain " + type);
            return null;
        }

        return weapon;
    }

    private int WeaponIndex(Weapon weapon)
    {
        if (weapon is null) return 0;

        int index = m_weapons.FindIndex(x => x.type == weapon.type);
        if (index < 0)
        {
            Debug.Log("WeaponInventory does not contain " + weapon.type);
        }
        return index;
    }

    // module for negative numbers
    int positiveMod(int a, int n)
    {
        return ((a % n) + n) % n;
    }

    public Weapon NextWeapon(Weapon current)
    {
        Weapon weapon = null;
        if (m_weapons.Count > 0)
        {
            int index = WeaponIndex(current);
            if (index >= 0)
                weapon = m_weapons[positiveMod((index + 1), m_weapons.Count)];
        }

        return weapon;

    }

    public Weapon PreviousWeapon(Weapon current)
    {
        Weapon weapon = null;
        if (m_weapons.Count > 0)
        {
            int index = WeaponIndex(current);
            if (index >= 0)
                weapon = m_weapons[positiveMod((index - 1), m_weapons.Count)];
        }
        return weapon;
    }
}
