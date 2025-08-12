using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerDataSO playerData; // Reference to player data scriptable object

    // Current stats
    internal float currentHealth;  
    internal float currentMoveSpeed; 
    internal float currentCritChance;
    internal float currentCritDamage;
    internal float currentBaseDamage;
    internal float currentAttackSpeed; 
    internal float currentRecovery; 
    internal float currentProjectileSpeed;

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
    }

    private void Start()
    {
        // Initialize experience cap as the first experience cap increase
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevelUpChecker();
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
            UIManager.Instance.UpdateHealth(currentHealth); // Update health in UI
            // ensure current health does not exceed max health
            if (currentHealth > playerData.MaxHealth)
            {
                currentHealth = playerData.MaxHealth;
            }
        }
    }

}
