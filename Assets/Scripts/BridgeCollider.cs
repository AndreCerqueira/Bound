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
        foreach (var colliderObject in bridgeOverpassColliders)
        {
            var collider = colliderObject.GetComponent<Collider2D>();
            collider.enabled = !isOverpass;
            player.sortingOrder = isOverpass ? 0 : 1;
        }

        foreach (var colliderObject in bridgeUnderpassColliders)
        {
            var collider = colliderObject.GetComponent<Collider2D>();
            collider.enabled = isOverpass;
            player.sortingOrder = isOverpass ? 0 : 1;
        }

        Debug.Log($"{(isOverpass ? "Underpass" : "Overpass")} colliders toggled.");
    }
}
