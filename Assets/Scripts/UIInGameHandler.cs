using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInGameHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro.text = "Best Score: " + GameManager.Instance.highScoreName + ": " + GameManager.Instance.highScore;
    }
}
