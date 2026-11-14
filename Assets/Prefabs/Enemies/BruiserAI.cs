using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruiserAI : MonoBehaviour
{
  public float movementSpeed = 0.1f;
  public Rigidbody2D body;
  public Animator animator;
  public Transform target;
  Vector2 movement;
  public float maxDistance = 3f;
  public float closeDistance = 1.2f;

  public int maxHealth = 200;
  public int currentHealth;

  public GameObject gameManager;

  public static bool enemyKilled;
  public static int count = 0;

  void Start()
  {
    enemyKilled = false;
    count++;
    currentHealth = maxHealth;
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    gameManager = GameObject.FindGameObjectWithTag("GameController");
  }

  void Update()
  {
    if(Vector2.Distance(target.position, transform.position) >= maxDistance){
      animator.SetFloat("Horizontal", transform.position.x);
      animator.SetFloat("Speed", transform.position.sqrMagnitude);
    }else{
      animator.SetFloat("Horizontal", 0);
      animator.SetFloat("Speed", 0);
    }
  }

  void FixedUpdate()
  {
    if(enemyKilled==true){
      enemyKilled = false;
    }
    if(target.position.x - transform.position.x > 0){ //flip enemy object over to face left if movement.x is less than 0 (left movement)
      transform.localRotation = Quaternion.Euler(0,180,0);
    }else if(target.position.x - transform.position.x < 0){
      transform.localRotation = Quaternion.Euler(0,0,0);
    }
    if(Vector2.Distance(target.position, transform.position) >= maxDistance){
      transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
    }else if(!(Vector2.Distance(target.position, transform.position) <= closeDistance)){
      transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * 1/5 * Time.deltaTime);
    }
 }

 public void TakeDamage(int damage)
 {
   float random = Random.value;
   if(random < .5){FindObjectOfType<AudioManager>().Play("EnemyHurt");}
   else{FindObjectOfType<AudioManager>().Play("EnemyHurt1");}

   currentHealth -= damage;
   animator.SetTrigger("Hurt");

   if(currentHealth <0)
   {
     Die();
   }
 }

 public void Die()
 {
   animator.SetBool("isDead", true);
   GetComponent<Collider2D>().enabled = false;
   GetComponent<BruiserCombat>().enabled = false;
   count--;
   enemyKilled = true;
   this.enabled = false;
 }
}
