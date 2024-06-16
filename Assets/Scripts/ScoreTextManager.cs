using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ScoreTextManager : MonoBehaviour
{
    public TextMeshProUGUI RedScoreText;
    public TextMeshProUGUI BlueScoreText;
    public TextMeshProUGUI RedResultText;
    public TextMeshProUGUI BlueResultText;

    private int _redScore = controller.RedScore;
    private int _blueScore = controller.BlueScore;
    // Start is called before the first frame update
    void Start()
    {
        RedScoreText.text = _redScore.ToString();
        BlueScoreText.text = _blueScore.ToString();
        if (_redScore > _blueScore)
        {
            RedResultText.text = "You Win!";
            BlueResultText.text = "You Lose...";
        }
        else
        {
            RedResultText.text = "You Lose...";
            BlueResultText.text = "You Win!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
