using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] WarningText warningText;
    [SerializeField] TextBoxHandler textBoxHandler;

    private void Start()
    {
        if (textBoxHandler == null)
        {
            textBoxHandler = FindObjectOfType<TextBoxHandler>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textBoxHandler.TurnOnTextBox();
            textBoxHandler.SetWarningText(warningText.getWarningText());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textBoxHandler.TurnOffTextBox();
        }
    }
}
