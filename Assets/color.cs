using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color : MonoBehaviour
{
    private controller _controller;
    private int row;
    private int col;
    [SerializeField] Material[] materialArray = new Material[6];
    Material cubeMaterial;

    // Start is called before the first frame update
    void Start()
    {
        row = Mathf.FloorToInt(transform.position.y) * -1 + 2 ;
        col = Mathf.FloorToInt(transform.position.x) + 2 ;
        _controller = GameObject.Find("GameManager").GetComponent<controller>();
        GetComponent<SpriteRenderer>().material = materialArray[0];
    }

    // Update is called once per frame
    void Update()
    {
        int CellValue = _controller.GetValue(row, col);
        if (CellValue == 0)
        {
            GetComponent<SpriteRenderer>().material = materialArray[0];
        }
        else if (CellValue == 1)
        {
            GetComponent<SpriteRenderer>().material = materialArray[2];
        }
        else if (CellValue == 2)
        {
            GetComponent<SpriteRenderer>().material = materialArray[3];
        }
        else if (CellValue == 3)
        {
            GetComponent<SpriteRenderer>().material = materialArray[4];
        }
        else if (CellValue == 4)
        {
            GetComponent<SpriteRenderer>().material = materialArray[5];
        }
    }
    public void OnTouched()
    {
        _controller.Pushed(row, col);
        //Debug.Log($"({row},{col}‚ªƒNƒŠƒbƒN‚³‚ê‚Ü‚µ‚½)");
    }
}