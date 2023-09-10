using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField field;

    void LockInput(TMP_InputField input)
    {
        if (input.text.Length > 0)
        {
            field.image.color = Color.white;
            GameManager.Instance.playerName = input.text;
        }
        else if (input.text.Length == 0)
        {
            field.image.color = Color.red;
            GameManager.Instance.playerName = input.text;
        }
    }

    public void Start()
    {
        //Adds a listener that invokes the "LockInput" method when the player finishes editing the main input field.
        //Passes the main input field into the method when "LockInput" is invoked
        field.onEndEdit.AddListener(delegate { LockInput(field); });
    }
}
