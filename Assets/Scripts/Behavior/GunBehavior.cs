using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera fpsCamera;
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private Transform bulletShotPosition;
    [SerializeField] private Transform mouseInputTransform;

    [Header("Particles")]
    [SerializeField] private ParticleSystem bulletHitParticle;
    [SerializeField] private ParticleSystem bulletShotParticle;

    [Header("Values")]
    [SerializeField] private int damageAmt;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float maxDistance;
    [SerializeField] private float zoomSpd;

    [SerializeField] private LayerMask enemyLayer;

    private PlayerInputScript mouseInput;
    private RaycastHit enemyHit;
    private Stats enemyStats;

    private float attackTimeCounter = 0f;
    private float targetFOV;

    private void Start() {
        mouseInput = mouseInputTransform.GetComponent<PlayerInputScript>();
    }

    private void Update() {

        Zoom();
        
        bool canShootVar = CanShoot();

        if(Input.GetKeyDown(KeyCode.Mouse0) && canShootVar) {

            //gunAnimator.Play(shoot_animation);
            gunAnimator.SetBool("Shot", true);
            Shoot();
            attackTimeCounter = 0f;
        }
    }

    private void Shoot() {

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out enemyHit, maxDistance, enemyLayer)) {

            Instantiate(bulletShotParticle, bulletShotPosition);
            Instantiate(bulletHitParticle, enemyHit.point, enemyHit.transform.rotation);
            enemyStats = enemyHit.transform.GetComponent<Stats>();

            enemyStats.Damage(damageAmt);
        }
    }

    private bool CanShoot() {

        if(attackTimeCounter >= attackCooldown) {

            gunAnimator.SetBool("Shot", false);
            return true;
        }
        attackTimeCounter += Time.deltaTime;
        return false;
    }

    private void Zoom() {

        fpsCamera.fieldOfView = Mathf.Lerp(fpsCamera.fieldOfView, targetFOV, Time.deltaTime * zoomSpd);

        if(mouseInput.GetRightMouseKey() == true) {

            targetFOV = 25;
            return;
        }
        targetFOV = 60;
    }

}
