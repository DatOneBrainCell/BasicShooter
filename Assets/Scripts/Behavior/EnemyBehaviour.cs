using System.Collections;
using System.Globalization;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform targetCheckStartPos;
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float maxDistance = -4;
    [SerializeField] private float rayHitDistance = 1;
    [SerializeField] private float attackCooldown = 5f;
    [SerializeField] private int attackAmount = 50;

    private Stats wallStats;
    private Stats enemyStats;
    private RaycastHit forwardHit;
    private GameObject player;
    private Collider enemyCollider;
    private GameObject spawnerGameObject;
    private SpawnEntities spawnEnemies;

    private float attackTimeCounter = 0f;
    private Vector3 playerLookAtPosition;

    //FOR ANIMATION
    private bool isAttacking = false;
    private bool isIdle = false;

    private const string PLAYER = "Player";
    private const string OBSTACLE = "Obstacle";
    private const string SPAWNER = "Spawner";

    private void Awake() {

        spawnerGameObject = GameObject.FindGameObjectWithTag(SPAWNER);
        spawnEnemies = spawnerGameObject.GetComponent<SpawnEntities>();
    }

    private void Start() {

        spawnEnemies.SetEnemyAliveAmt(1);

        enemyCollider = GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag(PLAYER);
        enemyStats = GetComponent<Stats>();
        StartCoroutine(CheckEnemyDeathCoroutine());
    }

    private void Update() {

        MoveTowardsPlayer();

    }

    //FUNCTIONS

    private void MoveTowardsPlayer() {

        ObtainPlayerXZPosition();

        if (!ForwardCheck()) {

            isIdle = false;
            transform.LookAt(playerLookAtPosition);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        
        if (transform.position.z <= maxDistance) {
            Destroy(gameObject);
        }
    }

    private void ObtainPlayerXZPosition() {

        float playerXPosition = player.transform.position.x;
        float playerZPosition = player.transform.position.z;

        playerLookAtPosition = new Vector3(playerXPosition, 0f, playerZPosition);
    }

    private bool ForwardCheck() {


        if (Physics.Raycast(targetCheckStartPos.position, targetCheckStartPos.forward, out forwardHit, rayHitDistance)) {

            //Debug.Log("Inside Raycast");
            isIdle = true;

            if(forwardHit.transform.tag == OBSTACLE) {
                
                //Debug.Log("Inside Raycast If");
                Attack(forwardHit);
            }
            return true;
        }
        return false;
    }

    private void Attack(RaycastHit forwardHit) {

        if(CanAttack()) {

            isIdle = false;
            isAttacking = true;

            wallStats = forwardHit.transform.GetComponent<Stats>();
            wallStats.Damage(attackAmount);

            attackTimeCounter = 0;
        }
    }

    private bool CanAttack() {

        if(attackTimeCounter >= attackCooldown) {

            return true;
        }
        attackTimeCounter += Time.deltaTime;

        isAttacking = false;
        return false;
    }

    //COROUTINES

    private IEnumerator CheckEnemyDeathCoroutine() {

        while (true) {
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            if (enemyStats.GetHealth() <= 0) {
                moveSpeed = 0f;
                attackAmount = 0;
                enemyCollider.enabled = false;

                Destroy(gameObject, 5f);
                yield break;
            }
            yield return null;
        }
    }

    //GET FUNCTIONS

    internal bool GetIsAttacking() {
        return isAttacking;
    }

    internal bool GetIsIdle() {
        return isIdle;
    }

    //BUILT IN FUNCTIONS

    private void OnDestroy() {

        spawnEnemies.SetEnemyAliveAmt(-1);
    }
}
