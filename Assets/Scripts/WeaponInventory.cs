﻿using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    public List<Weapon> m_prefabs;
    public List<Weapon> m_weapons;

    // Start is called before the first frame update
    void Start()
    {
        // instantiate all weapons in the inventory at start
        foreach (Weapon prefab in m_prefabs)
        {
            Weapon weapon = Instantiate(prefab, this.gameObject.transform);
            weapon.gameObject.SetActive(false);
            weapon.gameObject.transform.localPosition = weapon.offset;

            m_weapons.Add(weapon);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddWeapon(Weapon weapon)
    {
        if (!m_weapons.Contains(weapon))
        {
            m_weapons.Add(weapon);
        }
        else
        {
            Debug.Log("WeaponInventory already contains " + weapon.type);
        }
    }

    public GameObject GetWeapon(WeaponType type)
    {
        Weapon weapon = m_weapons.Find(x => x.type == type);
        if (!weapon)
        {
            Debug.Log("WeaponInventory does not contain " + type);
            return null;
        }

        return weapon.gameObject;
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