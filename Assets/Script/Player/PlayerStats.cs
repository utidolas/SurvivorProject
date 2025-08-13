using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerDataSO playerData; // Reference to player data scriptable object

    // Current stats
    public float currentHealth;

    [HideInInspector] public float currentMoveSpeed;
    [HideInInspector] public float currentCritChance;
    [HideInInspector] public float currentCritDamage;
    [HideInInspector] public float currentBaseDamage;
    [HideInInspector] public float currentAttackSpeed;
    [HideInInspector] public float currentRecovery;
    [HideInInspector] public float currentProjectileSpeed;
    [HideInInspector] public float currentMagnet;

    // Experience and level
    [Header("Experience and Level")]
    public int experience = 0;
    public int level = 1;
    public int experienceCap;

    // Class for defining level ranges and the corresponding experience cap increase
    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    public List<LevelRange> levelRanges;

    private void Awake()
    {
        currentHealth = playerData.MaxHealth; 
        currentMoveSpeed = playerData.MoveSpeed;
        currentCritChance = playerData.CritChange;
        currentCritDamage = playerData.CritDamage;
        currentBaseDamage = playerData.BaseDamage;
        currentAttackSpeed = playerData.AttackSpeed;
        currentRecovery = playerData.Recovery;
        currentProjectileSpeed = playerData.ProjectileSpeed;
        currentMagnet = playerData.Magnet;
    }

    private void Start()
    {
        // Initialize experience cap as the first experience cap increase
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    private void Update()
    {
        Recover();
        // Update health in UI
        UIManager.Instance.UpdateHealth(currentHealth); 
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevelUpChecker();
    }

    private void Recover()
    {
        if (currentHealth < playerData.maxHealth)
        {
            currentHealth += currentRecovery;

            // assure recover doesn't exceed player's max health
            if (currentHealth > playerData.MaxHealth)
            {
                currentHealth = playerData.MaxHealth;
            }
        }
    }

    internal void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience -= experienceCap;

            int experienceIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceIncrease;
        }
    }

    public void RestoreHealth(float amount)
    {
        // only heal if current health is less than max health
        if (currentHealth < playerData.MaxHealth)
        {
            currentHealth += amount;
            // ensure current health does not exceed max health
            if (currentHealth > playerData.MaxHealth)
            {
                currentHealth = playerData.MaxHealth;
            }
        }
    }

}
