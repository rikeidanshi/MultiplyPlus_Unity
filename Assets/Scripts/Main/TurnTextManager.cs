using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnTextManager : MonoBehaviour
{
    private Controller _controller;
    [SerializeField] private TextMeshProUGUI RedStateText;
    [SerializeField] private TextMeshProUGUI BlueStateText;
    private int Tarn;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GameObject.Find("GameManager").GetComponent<Controller>();
        Tarn = _controller.CurrentTarn;
    }

    // Update is called once per frame
    void Update()
    {
        Tarn = _controller.CurrentTarn;
        if (Tarn == 0)
        {
            RedStateText.text = "Your Turn";
            BlueStateText.text = "Opponent's Turn";
        }
        else if (Tarn == 1)
        {
            RedStateText.text = "Opponent's Turn";
            BlueStateText.text = "Your Turn";
        }
    }
}
