using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponType type = WeaponType.None;
    public uint magazineSize;
    public uint storedAmmo;
    public uint loadedAmmo;
    public GameObject bulletPrefab;
    public BulletData bulletData;
    public Transform bulletSpawn;

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
        loadedAmmo = Math.Min(storedAmmo, magazineSize);
        storedAmmo -= loadedAmmo;
    }

    public void Fire()
    {
        if (loadedAmmo <= 0)
        {
            // emtpy ammo sound?
            return;
        }

        // project and deal weapon damage
        // TODO use a pool of bullets
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        WeaponBullet bulletComp = bullet.GetComponent<WeaponBullet>();
        bulletData.weaponType = type;
        bulletComp.data = bulletData;
        bulletComp.source = gameObject;
        bulletComp.Shoot();

        // if there is ammo to shoot, reduce current ammo 
        loadedAmmo--;
    }

    public void AddAmmo(uint ammo)
    {
        storedAmmo += ammo;
    }

    public uint TotalAmmo()
    {
        return storedAmmo + loadedAmmo;
    }

    public uint LoadedAmmo()
    {
        return loadedAmmo;
    }
}
