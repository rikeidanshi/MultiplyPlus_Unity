using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleButtonManager : MonoBehaviour
{
    private bool isRedActive;
    private bool isRandomActive;
    private bool isBlueActive;

    [SerializeField] private Button RedButton;
    [SerializeField] private Button RandomButton;
    [SerializeField] private Button BlueButton;

    private Button redButton;
    private Color redButtonColor;
    private TextMeshProUGUI redButtonText;
    private Color redButtonTextColor;
    private Button randomButton;
    private Color randomButtonColor;
    private TextMeshProUGUI randomButtonText;
    private Color randomButtonTextColor;
    private Button blueButton;
    private Color blueButtonColor;
    private TextMeshProUGUI blueButtonText;
    private Color blueButtonTextColor;

    // Start is called before the first frame update
    void Start()
    {
        isRedActive = false;
        isRandomActive = true;
        isBlueActive = false;

        redButton = RedButton.GetComponent<Button>();
        redButtonColor = redButton.colors.normalColor;
        redButtonText = redButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        redButtonTextColor = redButtonText.color;

        randomButton = RandomButton.GetComponent<Button>();
        randomButtonColor = randomButton.colors.normalColor;
        randomButtonText = randomButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        randomButtonTextColor = randomButtonText.color;

        blueButton = BlueButton.GetComponent<Button>();
        blueButtonColor = blueButton.colors.normalColor;
        blueButtonText = blueButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        blueButtonTextColor = blueButtonText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRedActive)
        {
            redButtonColor = Color.red;
            redButtonTextColor = Color.white;
            randomButtonColor = Color.white;
            randomButtonTextColor = Color.purple;
            blueButtonColor = Color.white;
            blueButtonTextColor = Color.blue;
        }
        else if (isBlueActive)
        {
            redButtonColor = Color.white;
            redButtonTextColor = Color.red;
            randomButtonColor = Color.white;
            randomButtonTextColor = Color.purple;
            blueButtonColor = Color.blue;
            blueButtonTextColor = Color.white;
        }
        else 
        {
            redButtonColor = Color.white;
            redButtonTextColor = Color.white;
            randomButtonColor = Color.purple;
            randomButtonTextColor = Color.white;
            blueButtonColor = Color.white;
            blueButtonTextColor = Color.blue;
        }
    }
}
