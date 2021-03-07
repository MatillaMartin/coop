using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponType type = WeaponType.None;
    public Vector3 offset;

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
        // set ammo as big as the magazine size, or at least the tothal ammo available
        m_currentAmmo = Math.Min(m_totalAmmo, m_magSize);
        m_totalAmmo -= m_currentAmmo;
    }

    public void Shoot()
    {
        // if there is ammo to shoot, reduce current ammo 
        if (m_currentAmmo > 0)
        {
            m_currentAmmo--;
        }
    }

    private uint m_totalAmmo;
    private uint m_currentAmmo;
    private uint m_magSize;
}
