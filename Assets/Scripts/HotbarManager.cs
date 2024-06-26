using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HotbarManager : MonoBehaviour
{
    public static HotbarManager instance;

    [SerializeField]
    private PlayerInput _playerInput;

    private Slot[] _slots;

    public ITool selectedTool;

    private void Awake()
    {
        instance = this;

        _slots = GetComponentsInChildren<Slot>();

        // Set the first slot as highlighted
        _slots[0].isHighlighting = true;
    }

    private void OnEnable()
    {
        _playerInput.actions["SelectHotbarSlot"].performed += SelectHotbarSlot;
    }

    private void OnDisable()
    {
        _playerInput.actions["SelectHotbarSlot"].performed -= SelectHotbarSlot;
    }


    private void SelectHotbarSlot(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() < 1 || context.ReadValue<float>() > 9)
            return;

        DisableAllHighlighting();

        int slotNumber = (int)context.ReadValue<float>();
        _slots[slotNumber - 1].isHighlighting = true;

        // check if have tool in slot and set it as selected

        Debug.Log($"Selected hotbar slot: {slotNumber}");
    }


    private void DisableAllHighlighting()
    {
        foreach (var slot in _slots)
        {
            slot.isHighlighting = false;
        }
    }
}
