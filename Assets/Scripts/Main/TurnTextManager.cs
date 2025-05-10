using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnTextManager : MonoBehaviour
{
    private Controller _controller;
    [SerializeField] private TextMeshProUGUI RedStateText;
    [SerializeField] private TextMeshProUGUI BlueStateText;
    private int Turn;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GameObject.Find("GameManager").GetComponent<Controller>();
        Turn = _controller.CurrentTurn;
    }

    // Update is called once per frame
    void Update()
    {
        Turn = _controller.CurrentTurn;
        if (Turn == 0)
        {
            RedStateText.text = "Your Turn";
            BlueStateText.text = "Opponent's Turn";
        }
        else if (Turn == 1)
        {
            RedStateText.text = "Opponent's Turn";
            BlueStateText.text = "Your Turn";
        }
    }
}
