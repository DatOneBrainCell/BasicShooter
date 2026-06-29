using System.Collections;
using UnityEngine;

public class SpawnEntities : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyGameObjectPrefabs;
    [SerializeField] private GameObject[] bossGameObjectPrefabs;

    [SerializeField] private float spawnInterval;
    [SerializeField] private float waveInterval;
    [SerializeField] private int enemyAmount;
    [SerializeField] private int enemiesAlive;
    [SerializeField] private float waveCount;

    private BoxCollider spawnAreaCollider;

    private int currentEnemy;

    private void Awake() {

        spawnAreaCollider = GetComponent<BoxCollider>();
    }

    private void Start() {

        StartCoroutine(nameof(SpawnEnemiesCoroutine));
    }

    private IEnumerator SpawnEnemiesCoroutine() {

        for (int j = 0; j < waveCount; j++) {
            for (int i = 0; i < enemyAmount; i++) {
                yield return new WaitForSeconds(spawnInterval);
                SpawnEnemies();
                currentEnemy = i;
            }
            if(enemiesAlive != 0) {
                yield return new WaitUntil(() => enemiesAlive == 0);
            }
            
        }
        //if (enemyAmount - currentEnemy == 1) {
        //    SpawnBoss();
        //}
    }

    private void SpawnEnemies() {

        Bounds spawnAreaBounds = spawnAreaCollider.bounds;

        float randomBoundX = Random.Range(spawnAreaBounds.min.x, spawnAreaBounds.max.x);
        float randomBoundZ = Random.Range(spawnAreaBounds.min.z, spawnAreaBounds.max.z);

        Vector3 spawnAreaPosition = new Vector3(randomBoundX, transform.position.y, randomBoundZ);

        Instantiate(enemyGameObjectPrefabs[PickRandomEnemy()], spawnAreaPosition, Quaternion.identity, transform);
    }

    private void SpawnBoss() {

        Instantiate(bossGameObjectPrefabs[0], spawnAreaCollider.transform.position, Quaternion.identity);
    }

    private int PickRandomEnemy() {
        int randEnemyID = Random.Range(0, enemyGameObjectPrefabs.Length);
        return randEnemyID;
    }

    //SETTER

    internal void SetEnemyAliveAmt(int n) {
        enemiesAlive += n;
    }
}