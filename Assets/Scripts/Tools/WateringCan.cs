using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : ITool
{
    public string Name => "Watering Can";


    public void Use()
    {
        GridManager.instance.ChangeHighlightedTileToTilledSoil();
    }

}
