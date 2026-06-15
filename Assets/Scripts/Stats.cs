using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    [SerializeField] private int health;
    [SerializeField] private float despawnTime;

    private Animator animator;
    private Collider collider;
    private EnemyBehaviour enemyBehaviour;

    private const string IS_DYING = "IsDying";

    private void Start() {

        health = maxHealth;

        animator = transform.GetChild(0).GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    internal void Damage(int dmgAmt) {

        if (health <= 0 || dmgAmt >= health) {
            StartCoroutine(DestroyGameObject());
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

    IEnumerator DestroyGameObject() {

        if (animator != null) {

            animator.SetBool(IS_DYING, true);

            enemyBehaviour.enabled = false;

            if (collider  != null) {
                collider.enabled = false;
            }

            yield return new WaitForSeconds(despawnTime);

            Destroy(gameObject);
        }

        else {
            Destroy(gameObject);
        }
    }
}
