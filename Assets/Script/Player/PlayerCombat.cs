using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Combo Settings")]
    public List<AttacksSO> combo;
    private float lastClickedTime; // time when the last attack was clicked
    private float lastComboEnd; // time when the last combo ended
    private int comboCounter; // current combo count

    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] PlayerWeapon weapon; 

    private void Start()
    {
        // Get thecomponent's attached to this GameObject
        anim = GetComponent<Animator>(); 
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // change this to playerinput system
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        ExitAttack();
    }

    private void Attack()
    {
        // if the player is not in a combo, start a new one or continue the current one scaling the attack speed
        if (Time.time - lastComboEnd > 0.1f && comboCounter <= combo.Count)
        {
            CancelInvoke("EndCombo");

            // continue the current combo if the last attack was within 0.7 seconds scaling the attack speed
            if (Time.time - lastClickedTime >= 0.7f)
            {
                anim.runtimeAnimatorController = combo[comboCounter].animatorOvCtrl;
                anim.Play("Attack", 0, 0);
                anim.speed = 1; // scale the attack speed 
                weapon.damage = combo[comboCounter].damage;
                comboCounter++;
                lastClickedTime = Time.time;

                // if the combo is finished, reset the counter
                if (comboCounter + 1 > combo.Count)
                {
                    comboCounter = 0;
                }
            }
        }
    }

    // when to end attack animation
    private void ExitAttack()
    {
        // if combo is 90% done and the player is still in an attack combo, end the combo
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f && anim.GetCurrentAnimatorStateInfo(0).IsTag("AttackCombo"))
        {
            Invoke("EndCombo", 1);
        }
    }

    private void EndCombo()
    {
        comboCounter = 0;
        lastComboEnd = Time.time;
    }

    // Update the hitbox of the weapon based on the provided hitbox data, called by animation events
    public void UpdateHitbox(AttacksHitBoxSO hitBoxData)
    {
        BoxCollider2D boxCollider = weapon.GetComponent<BoxCollider2D>();
        if (boxCollider != null)
        {
            boxCollider.enabled = true;
            boxCollider.offset = new Vector2(hitBoxData.offset.x, hitBoxData.offset.y);
            boxCollider.size = new Vector2(hitBoxData.size.x, hitBoxData.size.y);
        }
    }

    // Enable the hitbox of the weapon and reset the hit list, called by animation events
    public void DisableHitboxAndResetHashList()
    {
        BoxCollider2D boxCollider = weapon.GetComponent<BoxCollider2D>();
        weapon.ResetHitList(); // Reset the hit list of the weapon to allow hitting enemies again
        if (boxCollider != null)
        {
            boxCollider.enabled = false;
        }
    }

    // Draw Gizmos to visualize the hitbox in the editor
    private void OnDrawGizmos()
    {
        if (weapon != null)
        {
            BoxCollider2D boxCollider = weapon.GetComponent<BoxCollider2D>();
            if (boxCollider != null && boxCollider.enabled)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(boxCollider.transform.position + (Vector3)boxCollider.offset, boxCollider.size);
            }
        }
    }
}
