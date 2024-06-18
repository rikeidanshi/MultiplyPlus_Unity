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
    private TextMeshProUGUI redButtonText;
    private Button randomButton;
    private TextMeshProUGUI randomButtonText;
    private Button blueButton;
    private TextMeshProUGUI blueButtonText;

    private Color purple = new Color(170f / 255f, 0f / 255f, 255f / 255f, 255f / 255f);

    public void RedPushed()
    {
        isRedActive = true;
        isRandomActive = false;
        isBlueActive = false;
    }

    public void RandomPushed()
    {
        isRedActive = false;
        isRandomActive = true;
        isBlueActive = false;
    }

    public void BluePushed()
    {
        isRedActive = false;
        isRandomActive = false;
        isBlueActive = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        isRedActive = false;
        isRandomActive = true;
        isBlueActive = false;

        redButton = RedButton.GetComponent<Button>();
        redButtonText = redButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        randomButton = RandomButton.GetComponent<Button>();
        randomButtonText = randomButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        blueButton = BlueButton.GetComponent<Button>();
        blueButtonText = blueButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRedActive)
        {
            RedButton.GetComponent<Image>().color = Color.red;
            redButtonText.color = Color.white;
            RandomButton.GetComponent<Image>().color = Color.white;
            randomButtonText.color = purple;
            BlueButton.GetComponent<Image>().color = Color.white;
            blueButtonText.color = Color.blue;
        }
        else if (isBlueActive)
        {
            RedButton.GetComponent<Image>().color = Color.white;
            redButtonText.color = Color.red;
            RandomButton.GetComponent<Image>().color = Color.white;
            randomButtonText.color = purple;
            BlueButton.GetComponent<Image>().color = Color.blue;
            blueButtonText.color = Color.white;
        }
        else 
        {
            RedButton.GetComponent<Image>().color = Color.white;
            redButtonText.color = Color.red;
            RandomButton.GetComponent<Image>().color = purple;
            randomButtonText.color = Color.white;
            BlueButton.GetComponent<Image>().color = Color.white;
            blueButtonText.color = Color.blue;
        }
    }
}
