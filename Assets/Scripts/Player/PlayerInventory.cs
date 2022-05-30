using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    bool hasKey = false;

    public bool OpenWithKey()
    {
        if (hasKey)
        {
            hasKey = false;
            return true;
        }
        return false;
    }

    public void GotKey()
    {
        hasKey = true;
    }


}
