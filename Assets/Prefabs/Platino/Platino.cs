using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platino : MonoBehaviour
{
    [SerializeField] GameObject platinoLight;
    [SerializeField] TextTrigger platinoMessage;
    DoorHandler[] doorHandler;
    int platinoCount;

    private void Awake()
    {
        doorHandler = FindObjectsOfType<DoorHandler>();
        platinoCount = doorHandler.Length;
        GetComponent<SpriteRenderer>().enabled = false;        
        platinoLight.SetActive(false);
        platinoMessage.enabled = false;

    }

    public void AwakePlatino()
    {
        platinoCount--;
        if (platinoCount == 0)
        {
            GetComponent<SpriteRenderer>().enabled = true;            
            platinoLight.SetActive(true);
            platinoMessage.enabled = true;
        }
    }    
}
