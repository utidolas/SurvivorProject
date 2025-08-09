using System.Collections.Generic;
using UnityEngine;

// CHUNK SIZE: 30x15 (width x height)

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition; // Determine position where isn't chunk
    public LayerMask terrainLayer;
    public GameObject currentChunk; // Current chunk the player is on
    PlayerController playerController;

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        // Check if the player is moving
        if (playerController.movementInput != Vector2.zero)
        {
            ChunkChecker();
        }
    }

    private void ChunkChecker()
    {
        if (!currentChunk) 
        {
            return;
        }

        #region CHUNCK CHECKER
        // RIGHT
        if (playerController.movementInput.x > 0 && playerController.movementInput.y == 0)
        {
            // Check if there is no terrain chunk to the right of the player
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainLayer))
            {
                // If no terrain chunk, set noTerrainPosition to the right of the player
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        // LEFT
        else if (playerController.movementInput.x < 0 && playerController.movementInput.y == 0)
        {
            // Check if there is no terrain chunk to the left of the player
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainLayer))
            {
                // If no terrain chunk, set noTerrainPosition to the left of the player
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        // UP
        else if (playerController.movementInput.y > 0 && playerController.movementInput.x == 0)
        {
            // Check if there is no terrain chunk above the player
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainLayer))
            {
                // If no terrain chunk, set noTerrainPosition to above the player
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        // DOWN
        else if (playerController.movementInput.y < 0 && playerController.movementInput.x == 0)
        {
            // Check if there is no terrain chunk below the player
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainLayer))
            {
                // If no terrain chunk, set noTerrainPosition to below the player
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        // RIGHT UP
        else if (playerController.movementInput.x > 0 && playerController.movementInput.y > 0)
        {
            // Check if there is no terrain chunk to the right and above the player
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Up").position, checkerRadius, terrainLayer))
            {
                // If no terrain chunk, set noTerrainPosition to the right and above the player
                noTerrainPosition = currentChunk.transform.Find("Right Up").position;
                SpawnChunk();
            }
        }
        // RIGHT DOWN
        else if (playerController.movementInput.x > 0 && playerController.movementInput.y < 0)
        {
            // Check if there is no terrain chunk to the right and below the player
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Down").position, checkerRadius, terrainLayer))
            {
                // If no terrain chunk, set noTerrainPosition to the right and below the player
                noTerrainPosition = currentChunk.transform.Find("Right Down").position;
                SpawnChunk();
            }
        }
        // LEFT UP
        else if (playerController.movementInput.x < 0 && playerController.movementInput.y > 0)
        {
            // Check if there is no terrain chunk to the left and above the player
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Up").position, checkerRadius, terrainLayer))
            {
                // If no terrain chunk, set noTerrainPosition to the left and above the player
                noTerrainPosition = currentChunk.transform.Find("Left Up").position;
                SpawnChunk();
            }
        }
        // LEFT DOWN
        else if (playerController.movementInput.x < 0 && playerController.movementInput.y < 0)
        {
            // Check if there is no terrain chunk to the left and below the player
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Down").position, checkerRadius, terrainLayer))
            {
                // If no terrain chunk, set noTerrainPosition to the left and below the player
                noTerrainPosition = currentChunk.transform.Find("Left Down").position;
                SpawnChunk();
            }
        }
        #endregion
    }

    private void SpawnChunk()
    {
        // spawn a random terrain chunk at noTerrainPosition
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);    
    }
}
