using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueButtonManager : MonoBehaviour
{
    public TextMeshProUGUI StateText;
    private int State = 1;

    public void PushButton()
    {
        if (State == 0)
        {
            StateText.text = "Å~";
            State = 1;
        }
        else
        {
            StateText.text = "+";
            State = 0;
        }
    }

    public int GetValue()
    {
        return State;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
