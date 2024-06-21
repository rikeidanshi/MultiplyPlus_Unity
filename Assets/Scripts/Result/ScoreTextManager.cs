using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI RedScoreText;
    [SerializeField] private TextMeshProUGUI BlueScoreText;
    [SerializeField] private TextMeshProUGUI RedResultText;
    [SerializeField] private TextMeshProUGUI BlueResultText;

    private int _redScore;
    private int _blueScore;
    // Start is called before the first frame update
    void Start()
    {
        _redScore = Controller.RedScore;
        _blueScore = Controller.BlueScore;

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
        Destroy(GameObject.Find("GameManager"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
