using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerActions : MonoBehaviour
{
    private Vector3Int _highlightedTilePosition => GridManager.instance.GetHighlightedTilePosition();


    private void OnFire(InputValue inputValue)
    {
        // log
        Debug.Log("Fire: " + _highlightedTilePosition);

        // log
        Debug.Log("Is Ground: " + GridManager.instance.IsHighlightedTileDirt());

        // if is ground, change tile to Tilled Soil

    }
}
