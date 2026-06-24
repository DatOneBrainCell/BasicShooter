using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class ControlAnimations : MonoBehaviour
{
    [SerializeField] private string attack_animation; 

    private Animator animator;
    private Stats stats;
    private EnemyBehaviour enemyBehaviour;

    private bool isDead = false;

    private const string IS_IDLE = "IsIdle";
    private const string IS_DYING = "IsDying";
    private const string IS_ATTACKING = "IsAttacking";

    private void Start() {

        animator = transform.GetChild(0).GetComponent<Animator>();
        stats = GetComponent<Stats>();
        enemyBehaviour = GetComponent<EnemyBehaviour>();
    }

    private void Update() {
        
        PlayAttackAnimation();
        PlayIdleAnimation();
        PlayDeathAnimation();
    }

    private void PlayDeathAnimation() {
        
        if (stats.GetHealth() <= 0) {

            isDead = true;
            animator.SetBool(IS_DYING, true);
        }
    }

    private void PlayAttackAnimation() {

        if (enemyBehaviour.GetIsAttacking() && !isDead) {

            animator.Play(attack_animation);
        }
        else {
            animator.SetBool(IS_ATTACKING, false);
        }
    }

    private void PlayIdleAnimation() {

        if (enemyBehaviour.GetIsIdle() && !isDead) {

            animator.SetBool(IS_IDLE, true);
        }
        else {
            animator.SetBool(IS_IDLE, false);
        }
    }
}
