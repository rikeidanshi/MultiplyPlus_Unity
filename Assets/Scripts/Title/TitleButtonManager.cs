using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleButtonManager : MonoBehaviour
{
    private enum firstAttack
    {
        Red,
        Random,
        Blue
    }
    private static firstAttack CurrentFirstAttack;
    public static int FirstAttack { get { return (int)CurrentFirstAttack; } }

    private static bool isDifficultActive;
    public static bool IsDifficultActive { get { return isDifficultActive; } }

    [SerializeField] private Button RedButton;
    [SerializeField] private Button RandomButton;
    [SerializeField] private Button BlueButton;
    [SerializeField] private Button DifficultButton;
    [SerializeField] private Button StartButton;

    private Button redButton;
    private TextMeshProUGUI redButtonText;
    private Button randomButton;
    private TextMeshProUGUI randomButtonText;
    private Button blueButton;
    private TextMeshProUGUI blueButtonText;
    private Button difficultButton;
    private TextMeshProUGUI difficultButtonText;

    private Color purple = new Color(170f / 255f, 0f / 255f, 255f / 255f, 255f / 255f);

    public void RedPushed()
    {
        CurrentFirstAttack = firstAttack.Red;
        RedButton.GetComponent<Image>().color = Color.red;
        redButtonText.color = Color.white;
        RandomButton.GetComponent<Image>().color = Color.white;
        randomButtonText.color = purple;
        BlueButton.GetComponent<Image>().color = Color.white;
        blueButtonText.color = Color.blue;
    }

    public void RandomPushed()
    {
        CurrentFirstAttack = firstAttack.Random;
        RedButton.GetComponent<Image>().color = Color.white;
        redButtonText.color = Color.red;
        RandomButton.GetComponent<Image>().color = purple;
        randomButtonText.color = Color.white;
        BlueButton.GetComponent<Image>().color = Color.white;
        blueButtonText.color = Color.blue;
    }

    public void BluePushed()
    {
        CurrentFirstAttack = firstAttack.Blue;
        RedButton.GetComponent<Image>().color = Color.white;
        redButtonText.color = Color.red;
        RandomButton.GetComponent<Image>().color = Color.white;
        randomButtonText.color = purple;
        BlueButton.GetComponent<Image>().color = Color.blue;
        blueButtonText.color = Color.white;
    }

    public void DifficultPushed()
    {
        if (isDifficultActive)
        {
            isDifficultActive = false;
            DifficultButton.GetComponent<Image>().color = Color.white;
            difficultButtonText.color = Color.black;
            difficultButtonText.text = "Normal Mode";
        }
        else
        {
            isDifficultActive = true;
            DifficultButton.GetComponent<Image>().color = Color.gray;
            difficultButtonText.color = Color.white;
            difficultButtonText.text = "Difficult Mode";
        }
    }

    public void StartPushed()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        CurrentFirstAttack = firstAttack.Random;
        isDifficultActive = false;

        redButton = RedButton.GetComponent<Button>();
        redButtonText = redButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        randomButton = RandomButton.GetComponent<Button>();
        randomButtonText = randomButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        blueButton = BlueButton.GetComponent<Button>();
        blueButtonText = blueButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        difficultButton = DifficultButton.GetComponent<Button>();
        difficultButtonText = DifficultButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
