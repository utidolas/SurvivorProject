using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition; // Determine position where isn't chunk
    public LayerMask terrainLayer;
    PlayerController playerController;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void ChunkChecker()
    {
        // RIGHT
        if (playerController.movementInput.x > 0 && playerController.movementInput.y == 0)
        {
            // Check if there is no terrain chunk to the right of the player
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20, 0, 0), checkerRadius, terrainLayer))
            {
                // If no terrain chunk, set noTerrainPosition to the right of the player
                noTerrainPosition = player.transform.position + new Vector3(20, 0, 0);
                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        // spawn a random terrain chunk at noTerrainPosition
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);    
    }
}
