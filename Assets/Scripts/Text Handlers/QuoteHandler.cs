using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuoteHandler : MonoBehaviour
{
    [SerializeField] GameObject background;
    [SerializeField] TextMeshProUGUI quoteText;
    [SerializeField] TextMeshProUGUI authorName;
    [SerializeField] TextMeshProUGUI enterMessage;
    [SerializeField] QuoteText quote;
    [SerializeField] Animator quoteAnimation;


    bool quoteIsOn;

    private void Awake()
    {

    }

    private void Start()
    {
        quoteText.text = quote.getText();
        authorName.text = quote.getAuthor();
        enterMessage.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            quoteAnimation.SetTrigger("Fade Out");
        }
    }

    public void QuoteOn()
    {
        enterMessage.enabled = true;
        quoteIsOn = true;
    }

    public void StartPlay()
    {
        background.SetActive(false);
        FindObjectOfType<Move>().StartPlay();
        // player can play
    }
}
