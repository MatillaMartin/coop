using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int health;
    public int maxHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int amount, WeaponType weapon = WeaponType.None, GameObject source = null)
    {
        health -= amount;
        if (health <= 0)
        {
            // ded
            health = 0;

            // TODO send a death event
            Destroy(gameObject);
        }
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(maxHealth, health + amount);
    }
}
