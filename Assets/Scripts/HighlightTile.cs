using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HighlightTile : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Vector3Int? previousPosition;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        GridManager.instance.highlightTileMap.ClearAllTiles();

        if (playerMovement.isMoving)
        {
            previousPosition = null;
            return;
        }

        Vector3Int mouseCellPos = GridManager.instance.GetMouseCellPosition();
        Vector3Int objectCellPos = GridManager.instance.GetObjectCellPosition(this.transform.position);
        Vector3Int objectFinalCellPos = (previousPosition == null) ? objectCellPos : previousPosition.Value;
        Vector3Int position = (GridManager.instance.IsWithinHighlightRange(mouseCellPos, objectCellPos) ? mouseCellPos : objectFinalCellPos);
        
        GridManager.instance.SetHighlightTile(position);
        previousPosition = position;
    }
}
