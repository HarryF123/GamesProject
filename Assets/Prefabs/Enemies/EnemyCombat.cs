using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
  public Animator animator;
  public Transform attackPoint;
  public float attackRange = 0.5f;
  public float close_Enough_To_Attack = 1.0f;
  public LayerMask playerLayer;
  public Transform target;

  public int attackDamage = 25;
  public float attackRate = 3f;
  float nextAttack = 0f;

  void Start()
  {
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
  }

  void FixedUpdate()
  {
    if(GetComponent<EnemyAI>().enabled != false){
      if((Vector2.Distance(target.position, transform.position) <= close_Enough_To_Attack)&&(Time.time >= nextAttack)){
        Attack();
        nextAttack = Time.time + 1f;
      }
    }
  }

  void Attack()
  {
    //play animation
    animator.SetTrigger("Attack");

    //detect enemies in range of Attack
    Collider2D player = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

    //damage them
    if(player != null)
    {
      float random = Random.value;
      if(random < .25){FindObjectOfType<AudioManager>().Play("SwordClash");}
      else if(random > .25 && random < .5){FindObjectOfType<AudioManager>().Play("SwordClash1");}
      else if(random > .5 && random < .75){FindObjectOfType<AudioManager>().Play("SwordClash2");}
      else{FindObjectOfType<AudioManager>().Play("SwordClash3");}

      player.GetComponent<PlayerScript>().TakeDamage(attackDamage);
      Debug.Log("Player hit"+player.name);
    }
  }

  void OnDrawGizmosSelected(){
    if(attackPoint == null)
    {
      return;
    }
    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
  }
}
