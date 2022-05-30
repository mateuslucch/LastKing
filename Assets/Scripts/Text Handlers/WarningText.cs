using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Warning Text", menuName = "ScriptableObjects/Warning Text", order = 1)]
public class WarningText : ScriptableObject
{
    [TextArea(0,20)]
    public string warningText;

    public string getWarningText()
    {
        return warningText;
    }

}