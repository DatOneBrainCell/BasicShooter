using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    private Stats gateStats;

    private void Start() {
        
        gateStats = GetComponent<Stats>();
    }

    private void Update() {
        if (gateStats.GetHealth() <= 0) {

            Destroy(gameObject);
        }
    }
}
