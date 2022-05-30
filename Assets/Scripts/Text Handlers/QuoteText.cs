using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Quote Text", menuName = "ScriptableObjects/Quote Text", order = 1)]
public class QuoteText : ScriptableObject
{
    [TextArea(0, 20)]
    public string quoteText;
    public string authorText;

    public string getText()
    {
        return quoteText;
    }

    public string getAuthor()
    {
        return authorText;
    }

}