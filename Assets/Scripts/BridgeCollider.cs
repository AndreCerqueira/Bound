using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCollider : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer player;

    [SerializeField]
    private bool isOverpass;

    [SerializeField]
    private GameObject[] bridgeOverpassColliders;

    [SerializeField]
    private GameObject[] bridgeUnderpassColliders;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ToggleColliders();
    }

    private void ToggleColliders()
    {
        var colliders = isOverpass ? bridgeOverpassColliders : bridgeUnderpassColliders;

        foreach (var colliderObject in colliders)
        {
            var collider = colliderObject.GetComponent<Collider2D>();
            collider.enabled = !collider.enabled;

            player.sortingOrder = isOverpass ? 0 : 1;
        }

        Debug.Log($"{(isOverpass ? "Underpass" : "Overpass")} colliders toggled.");
    }
}
