using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;

    private Stats gateStats;

    private void Start() {
        
        gateStats = GetComponent<Stats>();
        healthBar.SetMaxHealthOnHealthBar(gateStats.GetMaxHealth());
    }

    private void Update() {

        healthBar.SetHealthOnHealthBar(gateStats.GetHealth());

        if (gateStats.GetHealth() <= 0) {

            Destroy(gameObject);
        }
    }
}
