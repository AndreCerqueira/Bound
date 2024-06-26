using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


/// <summary>
/// Manages the different tilemaps in the game, allowing operations like setting and getting the position of highlighted tiles.
/// </summary>
public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [Header("Tilemaps")]
    public Tilemap obstaclesTilemap;
    public Tilemap groundTilemap;
    public Tilemap farmLandTilemap;
    public Tilemap waterTilemap;
    public Tilemap vegetationTilemap;
    public Tilemap highlightTileMap;

    [Header("Tiles")]
    public TileBase highlightTile;
    public TileBase soilTile;
    public TileBase tilledSoilTile;
    public TileBase moistenSoilTile;


    void Start()
    {
        instance = this;
    }


    /// <summary>
    /// Sets a highlighted tile at the specified position.
    /// </summary>
    /// <param name="position">The position of the tile to be highlighted.</param>
    public void SetHighlightTile(Vector3Int position)
    {
        highlightTileMap.SetTile(position, highlightTile);
    }


    /// <summary>
    /// Gets the cell position in the tilemap based on the mouse position.
    /// </summary>
    /// <returns>The cell position in the tilemap where the mouse is located.</returns>
    public Vector3Int GetMouseCellPosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return highlightTileMap.WorldToCell(mouseWorldPos);
    }


    /// <summary>
    /// Gets the cell position in the tilemap based on an object's position.
    /// </summary>
    /// <param name="objectPosition">The position of the object in the world.</param>
    /// <returns>The cell position in the tilemap where the object is located.</returns>
    public Vector3Int GetObjectCellPosition(Vector3 objectPosition)
    {
        return highlightTileMap.WorldToCell(objectPosition);
    }


    /// <summary>
    /// Checks if the mouse position is within the specified range relative to the object's position, excluding the object's own tile.
    /// </summary>
    /// <param name="mouseCellPos">The cell position of the mouse.</param>
    /// <param name="objectCellPos">The cell position of the object.</param>
    /// <param name="range">The range to check within.</param>
    /// <returns>True if the mouse position is within range, false otherwise.</returns>
    public bool IsWithinHighlightRange(Vector3Int mouseCellPos, Vector3Int objectCellPos, int range = 1)
    {
        return Mathf.Abs(mouseCellPos.x - objectCellPos.x) <= range && Mathf.Abs(mouseCellPos.y - objectCellPos.y) <= range;
    }


    /// <summary>
    /// Gets the position of the highlighted tile in the tilemap.
    /// </summary>
    /// <returns>The position of the highlighted tile. If there is no highlighted tile, returns Vector3Int.zero.</returns>
    public Vector3Int GetHighlightedTilePosition()
    {
        foreach (Vector3Int pos in highlightTileMap.cellBounds.allPositionsWithin)
        {
            if (highlightTileMap.HasTile(pos))
                return pos;
        }

        return Vector3Int.zero;
    }


    // check if the highlighted tile is a dirt tile

    /// <summary>
    /// Checks if the highlighted tile is a dirt tile.
    /// </summary>
    /// <returns>True if the highlighted tile is a dirt tile, false otherwise.</returns>
    public bool IsHighlightedTileDirt()
    {
        return groundTilemap.GetTile(GetHighlightedTilePosition()) == soilTile;
    }


    /// <summary>
    /// Changes the highlighted tile to tilled soil.
    /// </summary>
    /// <remarks>
    /// The highlighted tile must be a dirt tile to be changed to tilled soil.
    /// </remarks>
    public void ChangeHighlightedTileToTilledSoil()
    {
        if (!IsHighlightedTileDirt())
            return;
        
        groundTilemap.SetTile(GetHighlightedTilePosition(), tilledSoilTile);
    }


    /// <summary>
    /// Changes the highlighted tilled tile to moisten soil.
    /// </summary>
    /// <remarks>
    /// The highlighted tile must be a tilled soil tile to be changed to moisten soil.
    /// </remarks>
    public void ChangeHighlightedTilledTileToMoistenSoil()
    {
        if (groundTilemap.GetTile(GetHighlightedTilePosition()) != tilledSoilTile)
            return;

        groundTilemap.SetTile(GetHighlightedTilePosition(), moistenSoilTile);
    }

}
