using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    [SerializeField] private int health;

    private void Start() {

        health = maxHealth;
    }

    internal void Damage(int dmgAmt) {

        if (health <= 0 || dmgAmt >= health) {
            Destroy(gameObject);
        }
        else {
            health -= Random.Range(dmgAmt - 7, dmgAmt + 5);
        }
    }

    internal void Heal(int healAmt) {

        if (health >= maxHealth) {
            health = maxHealth;
        }
        else {
            health += healAmt;
        }
    }
}
