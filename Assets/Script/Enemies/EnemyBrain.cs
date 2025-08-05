using System;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyBrain : MonoBehaviour, IDamageable, ITriggerCheckable
{
    [Header("Enemy Settings")]
    public EnemyDataSO enemyData; // Reference to the EnemyData ScriptableObject

    // References to components
    [NonSerialized] public Rigidbody2D rb; 
    [NonSerialized] public EnemyAnimations enemyAnimations; 

    [Header("Game Object References")]
    // Reference to other GameObjects   
    public GameObject player; 
    [SerializeField] private GameObject popUpDamage; 
    public GameObject enemyAttackHitBox; 

    [Header("Enemy Stats")]
    // enemy stats got from the EnemyData ScriptableObject
    public float health;
    public float maxHealth;
    public float speed;
    public float damage;
     
    # region State Machine Variables
    public EnemyStateMachine EnemyStateMachine { get; set; }
    public EnemyChaseState EnemyChaseState { get; set; }
    public EnemyAttackState EnemyAttackState { get; set; }
    #endregion

    #region Animation Triggers
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        EnemyStateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType); // Call the AnimationTriggerEvent method of the current state
    }

    public enum AnimationTriggerType
    {
        Attack,
        Hurt
    }
    #endregion

    public bool IsWithAttackDistance { get; set; }
    

    private void Awake()
    {
        // Initialize the state machine and states
        EnemyStateMachine = new EnemyStateMachine();
        EnemyChaseState = new EnemyChaseState(this, EnemyStateMachine);
        EnemyAttackState = new EnemyAttackState(this, EnemyStateMachine);

        // Get component's attached to this GameObject
        rb = GetComponent<Rigidbody2D>();
        enemyAnimations = GetComponent<EnemyAnimations>();
        player = GameObject.FindGameObjectWithTag("Player"); // Find the Player GameObject by tag
    }

    private void Start()
    {
        // initialize enemy data
        health = enemyData.Health;
        maxHealth = enemyData.MaxHealth;
        speed = enemyData.Speed;
        damage = enemyData.Damage;

        // initialize the state machine
        EnemyStateMachine.Initialize(EnemyChaseState);
    }

    private void Update()   
    {
        EnemyStateMachine.CurrentEnemyState.FrameUpdate(); // Call the FrameUpdate method of the current state
    }

    private void FixedUpdate()
    {
        EnemyStateMachine.CurrentEnemyState.PhyshicsUpdate(); // Call the PhyshicsUpdate method of the current state

    }

    // ============== Implementation of IDamageable interface ==============
    public void TakeDamage(float damageAmount)
    {
        // Play the damage animation 
        enemyAnimations.DamageAnimation();

        // Reduce health by the damage amount
        health -= damageAmount;

        // Instantiate a damage pop-up a little higher than the enemy and set the text of the pop-up to the damage amount
        GameObject popUp = Instantiate(popUpDamage, new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z) , Quaternion.identity);
        popUp.GetComponentInChildren<TMP_Text>().text = damageAmount.ToString();

        // Check if health is less than or equal to zero, and if so, call the Die method
        if (health <= 0)
        {
            Die();
        }
    }
    
    public void Die()
    {
        // Handle enemy death
        Destroy(gameObject); // Destroy the enemy GameObject
    }

    // =========================================================================
    public void SetAttackDistance(bool isWithAttackDistance)
    {
        IsWithAttackDistance = isWithAttackDistance; // Set the IsWithAttackDistance property
    }

}
