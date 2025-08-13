using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    // Creating a singleton 
    public static CharacterSelector instance;

    // Get the playerdata (set in the buttons in our menu)
    public PlayerDataSO playerData;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("Extra " + this + "DELETED");
            Destroy(gameObject);
        }
    }

    // Method that any script can call to get the "PlayerDataSO"
    public static PlayerDataSO GetData()
    {
        return instance.playerData;
    }

    // Method to our buttons call (so they can set the PlayerDataSO they want)
    public void SelectCharacter(PlayerDataSO character)
    {
        playerData = character;
    }

    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}
