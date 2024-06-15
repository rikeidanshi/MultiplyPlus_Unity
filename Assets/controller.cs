using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    private enum tarn
    {
        Red,
        Blue
    }
    private tarn Tarn = tarn.Red;
    
    private enum CellState
    {
        Empty,
        Red,
        nRed,
        Blue,
        nBlue
    }
    private CellState[,] _gameBoard = new CellState[5, 5];

    private RedButtonManager _redButtonManager;
    private BlueButtonManager _blueButtonManager;

    public int GetValue(int row, int col)
    {
        return (int)_gameBoard[row, col];
    }

    public void Pushed(int row, int col)
    {
        if (Tarn == tarn.Red)
        {
            if (_gameBoard[row, col] == CellState.Empty)
            { 
                _gameBoard[row, col] = CellState.nRed;

                int Direction = _redButtonManager.GetValue();
                if (Direction == 0 )
                {
                    for (int i = row + 1; i <= 4; i++)
                    {
                        if (_gameBoard[i, col] != CellState.nRed)
                        {
                            _gameBoard[i, col] = CellState.Red;
                        }
                    }
                    for (int i = row - 1; i >= 0; i--)
                    {
                        if (_gameBoard[i, col] != CellState.nRed)
                        {
                            _gameBoard[i, col] = CellState.Red;
                        }
                    }
                    for (int i = col + 1; i <= 4; i++)
                    {
                        if (_gameBoard[row, i] != CellState.nRed)
                        {
                            _gameBoard[row, i] = CellState.Red;
                        }
                    }
                    for (int i = col - 1; i >= 0; i--)
                    {
                        if (_gameBoard[row, i] != CellState.nRed)
                        {
                            _gameBoard[row, i] = CellState.Red;
                        }
                    }
                }
                else
                {
                    int i = row;
                    int j = col;
                    while (i < 4 && j < 4)
                    {
                        i++;
                        j++;
                        if (_gameBoard[i, j] != CellState.nRed)
                        {
                            _gameBoard[i, j] = CellState.Red;
                        }
                    }
                    i = row;
                    j = col;
                    while (i < 4 && j > 0)
                    {
                        i++;
                        j--;
                        if (_gameBoard[i, j] != CellState.nRed)
                        {
                            _gameBoard[i, j] = CellState.Red;
                        }
                    }
                    i = row;
                    j = col;
                    while (i > 0 && j < 4)
                    {
                        i--;
                        j++;
                        if (_gameBoard[i, j] != CellState.nRed)
                        {
                            _gameBoard[i, j] = CellState.Red;
                        }
                    }
                    i = row;
                    j = col;
                    while (i > 0 && j > 0)
                    {
                        i--;
                        j--;
                        if (_gameBoard[i, j] != CellState.nRed)
                        {
                            _gameBoard[i, j] = CellState.Red;
                        }
                    }
                }
                Tarn = tarn.Blue;
            }
        }
        else
        {
            if (_gameBoard[row, col] == CellState.Empty)
            {
                _gameBoard[row, col] = CellState.nBlue;

                int Direction = _blueButtonManager.GetValue();
                if (Direction == 0)
                {
                    for (int i = row + 1; i <= 4; i++)
                    {
                        if (_gameBoard[i, col] != CellState.nBlue)
                        {
                            _gameBoard[i, col] = CellState.Blue;
                        }
                    }
                    for (int i = row - 1; i >= 0; i--)
                    {
                        if (_gameBoard[i, col] != CellState.nBlue)
                        {
                            _gameBoard[i, col] = CellState.Blue;
                        }
                    }
                    for (int i = col + 1; i <= 4; i++)
                    {
                        if (_gameBoard[row, i] != CellState.nBlue)
                        {
                            _gameBoard[row, i] = CellState.Blue;
                        }
                    }
                    for (int i = col - 1; i >= 0; i--)
                    {
                        if (_gameBoard[row, i] != CellState.nBlue)
                        {
                            _gameBoard[row, i] = CellState.Blue;
                        }
                    }
                }
                else
                {
                    int i = row;
                    int j = col;
                    while (i < 4 && j < 4)
                    {
                        i++;
                        j++;
                        if (_gameBoard[i, j] != CellState.nBlue)
                        {
                            _gameBoard[i, j] = CellState.Blue;
                        }
                    }
                    i = row;
                    j = col;
                    while (i < 4 && j > 0)
                    {
                        i++;
                        j--;
                        if (_gameBoard[i, j] != CellState.nBlue)
                        {
                            _gameBoard[i, j] = CellState.Blue;
                        }
                    }
                    i = row;
                    j = col;
                    while (i > 0 && j < 4)
                    {
                        i--;
                        j++;
                        if (_gameBoard[i, j] != CellState.nBlue)
                        {
                            _gameBoard[i, j] = CellState.Blue;
                        }
                    }
                    i = row;
                    j = col;
                    while (i > 0 && j > 0)
                    {
                        i--;
                        j--;
                        if (_gameBoard[i, j] != CellState.nBlue)
                        {
                            _gameBoard[i, j] = CellState.Blue;
                        }
                    }
                }
                Tarn = tarn.Red;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _redButtonManager = GameObject.Find("RedButtonManager").GetComponent<RedButtonManager>();
        _blueButtonManager = GameObject.Find("BlueButtonManager").GetComponent<BlueButtonManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
