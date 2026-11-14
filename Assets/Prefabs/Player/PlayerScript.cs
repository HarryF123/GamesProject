using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D body;
    public Animator animator;
    Vector2 movement;
    public int maxHealth = 100;
    public int currentHealth;
    public bool regenHealth = false;

    public GameObject sceneloader;
    public HealthBar healthBar;

    void Start()
    {
      sceneloader = GameObject.FindWithTag("SceneController");
      currentHealth = maxHealth;
      healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
      if(movement.x < 0){ //flip player object over to face left if movement.x is less than 0 (left movement)
        transform.localRotation = Quaternion.Euler(0,180,0);
      }else if(movement.x > 0){
        transform.localRotation = Quaternion.Euler(0,0,0);
      }
      body.MovePosition(body.position + movement * movementSpeed * Time.fixedDeltaTime);

      if(currentHealth < maxHealth && regenHealth == false )
      {
          regenHealth = true;
          StartCoroutine("RegenHealth");
      }
    }

    IEnumerator RegenHealth()
    {
      currentHealth += 2;
      healthBar.SetHealth(currentHealth);
      yield return new WaitForSeconds(1);
      regenHealth = false;
    }

    public void TakeDamage(int damage)
    {
      float random = Random.value;
      if(random < .5){FindObjectOfType<AudioManager>().Play("Hurt");}
      else{FindObjectOfType<AudioManager>().Play("Hurt1");}
      if(!(animator.GetBool("Block")))
      {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        healthBar.SetHealth(currentHealth);
      }else{
        currentHealth -= (int) damage * 1/4;
        animator.SetTrigger("Blocked");
        healthBar.SetHealth(currentHealth);
      }
      if(currentHealth < 0)
      {
        Die();
      }
    }

    public void Die()
    {
      animator.SetBool("isDead", true);
      float random = Random.value;
      if(random < .5){FindObjectOfType<AudioManager>().Play("Dead");}
      else{FindObjectOfType<AudioManager>().Play("Dead1");}


      this.GetComponent<BoxCollider2D>().enabled = false;
      ExitGame();
    }

    public void ExitGame()
    {
      sceneloader.GetComponent<SceneChange>().LoadMenu();
    }
}
