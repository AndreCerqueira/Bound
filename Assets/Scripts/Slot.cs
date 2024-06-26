
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private int _slotNumber;

    private bool _isHighlighting;

    public bool isHighlighting
    {
        get => _isHighlighting;
        set
        {
            _isHighlighting = value;
            _highlightBorder.enabled = value;
        }
    }

    private int _amount;

    [Header("Components")]
    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _amountText;
    [SerializeField] private TextMeshProUGUI _slotNumberText;
    [SerializeField] private Image _highlightBorder;


    private void Awake()
    {
        _slotNumberText.text = _slotNumber.ToString();
    }

}
