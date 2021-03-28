using UnityEngine;

[System.Serializable]
public class BulletData
{
    [HideInInspector]
    public WeaponType weaponType;
    public int damage;
    public float speed;
}

public class WeaponBullet : MonoBehaviour
{
    [HideInInspector]
    public BulletData data;
    public GameObject source;
    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        rigid.velocity = gameObject.transform.forward * data.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        HealthController health = other.gameObject.GetComponent<HealthController>();
        if (health)
        {
            // deal damage, pass in info about the damage
            health.Damage(data.damage, data.weaponType, source);

            // destroy ourselves after dealing damage
            // TODO use bullet pool
            Destroy(gameObject);
        }
    }

}
