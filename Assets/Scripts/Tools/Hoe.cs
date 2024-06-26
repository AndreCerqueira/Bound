using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hoe : ITool
{
    public string Name => "Hoe";


    public void Use()
    {
        GridManager.instance.ChangeHighlightedTileToTilledSoil();
    }

}
