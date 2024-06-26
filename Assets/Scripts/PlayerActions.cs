using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerActions : MonoBehaviour
{
    private Vector3Int _highlightedTilePosition => GridManager.instance.GetHighlightedTilePosition();

    private ITool _selectedTool => HotbarManager.instance.selectedTool;


    private void OnFire(InputValue inputValue)
    {
        _selectedTool.Use();
    }
}
