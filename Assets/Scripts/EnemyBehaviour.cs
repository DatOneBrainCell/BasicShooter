using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform targetCheckStartPos;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxDistance;
    [SerializeField] private float rayHitDistance;
    [SerializeField] private float attackCooldown = 5f;

    private Stats wallStats;
    private RaycastHit forwardHit;
    private GameObject player;

    private float attackTimeCounter;
    private Vector3 playerLookAtPosition;

    private const string PLAYER = "Player";
    private const string ENEMY = "Enemy";
    private const string OBSTACLE = "Obstacle";

    private void Start() {

        player = GameObject.FindGameObjectWithTag(PLAYER);
    }

    private void Update() {

        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer() {

        ObtainPlayerXZPosition();

        if (!ForwardCheck()) {

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

            //Debug.Log("Inside Attack");

            wallStats = forwardHit.transform.GetComponent<Stats>();
            wallStats.Damage(50);

            attackTimeCounter = 0;
        }
    }

    private bool CanAttack() {

        if(attackTimeCounter >= attackCooldown) {

            return true;
        }
        attackTimeCounter += Time.deltaTime;
        return false;
    }

}
