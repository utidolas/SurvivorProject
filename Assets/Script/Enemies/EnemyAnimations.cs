using NUnit.Framework.Constraints;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    // Reference to components
    private Animator anim; 
    private Rigidbody2D rb; 
    private GameObject player; // Reference to the Player GameObject

    private void Start()
    {
        // Get components attached to this GameObject
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // Find the Player GameObject by tag
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void WalkAnimation(float speed)
    {

        anim.SetFloat("xVelocity", speed);

        Vector3 direction = (player.transform.position - transform.position).normalized;

        // rotate the enemy based on movement direction
        if (player != null)
        {
            // if player is on the right side of the enemy, face right
            if (direction.x > 0)
            {
                // Face right
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (direction.x < 0)
            {
                // Face left
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

    }

    public void IdleAnimation()
    {
        // Reset the xVelocity parameter to 0 for idle animation
        anim.SetFloat("xVelocity", 0f);
    }

    public void AttackAnimation()
    {
        // Play the attack animation
        anim.SetTrigger("Enemy_Attack");
    }


    public void DamageAnimation()
    {
        // Play the damage animation
        anim.SetTrigger("Hurt");
    }

}
