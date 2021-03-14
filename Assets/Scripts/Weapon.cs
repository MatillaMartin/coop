using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponType type = WeaponType.None;
    public Vector3 offset;

    private uint m_storedAmmo;
    private uint m_currentAmmo;
    private uint m_magSize;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reload()
    {
        // set ammo as big as the magazine size, or at least the stored ammo available
        m_currentAmmo = Math.Min(m_storedAmmo, m_magSize);
        m_storedAmmo -= m_currentAmmo;
    }

    public void Shoot()
    {
        // if there is ammo to shoot, reduce current ammo 
        if (m_currentAmmo > 0)
        {
            m_currentAmmo--;
        }
    }

    public void AddAmmo(uint ammo)
    {
        m_storedAmmo += ammo;
    }

    public uint Ammo()
    {
        return m_storedAmmo + m_currentAmmo;
    }
}
