using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public Transform blockPoint;
    public float blockRange = 0.4f;

    public int attackDamage = 40;
    public float attackRate = 2f;
    float nextAttack = 0f;

    void Update()
    {
      if(Input.GetKey(KeyCode.O) || Input.GetMouseButton(1))
      {
        Block();
      }else if(Input.GetKeyUp(KeyCode.O) || Input.GetMouseButtonUp(1))
      {
        animator.SetBool("Block", false);
      }

      if(Time.time >= nextAttack){
        if(Input.GetKeyDown(KeyCode.I) || Input.GetMouseButtonUp(0))
        {
          Attack();
          nextAttack = Time.time + 1f/attackRate;
        }
     }
    }

    void Block()
    {
      animator.SetBool("Block", true);

      //detect blocks and take 1/4 damage
      Collider2D enemyBlocked = Physics2D.OverlapCircle(blockPoint.position, blockRange, enemyLayer);

      if(enemyBlocked != null)
      {//if block detected, play block animation
        animator.SetTrigger("Blocked");
      }
    }

    void Attack()
    {
      //play animation
      animator.SetTrigger("Attack");

      //detect enemies in range of Attack
      Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

      //damage them
      if(enemiesHit != null)
      {
        float random = Random.value;
        if(random < .25){FindObjectOfType<AudioManager>().Play("SwordClash");}
        else if(random > .25 && random < .5){FindObjectOfType<AudioManager>().Play("SwordClash1");}
        else if(random > .5 && random < .75){FindObjectOfType<AudioManager>().Play("SwordClash2");}
        else{FindObjectOfType<AudioManager>().Play("SwordClash3");}
      }
      foreach(Collider2D enemy in enemiesHit)
      {
        if(enemy.tag == "Bruiser")
        {
        enemy.GetComponent<BruiserAI>().TakeDamage(attackDamage);
        }
        else if(enemy.tag == "Enemy")
        {
         enemy.GetComponent<EnemyAI>().TakeDamage(attackDamage);
        }
      }
    }



    void OnDrawGizmosSelected(){
      if(attackPoint == null)
      {
        return;
      }
      Gizmos.DrawWireSphere(blockPoint.position, blockRange);
      Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
