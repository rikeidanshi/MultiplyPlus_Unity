using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class controller : MonoBehaviour
{
    private enum tarn
    {
        Red,
        Blue
    }
    private tarn _currentTarn = tarn.Red;

    public int CurrentTarn
    {
        get { return (int)_currentTarn; }
    }
    
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
        if (_currentTarn == tarn.Red)
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
                TarnEnd();
                _currentTarn = tarn.Blue;
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
                TarnEnd();
                _currentTarn = tarn.Red;
            }
        }
    }

    private void TarnEnd()
    {
        CellState targetValueA = CellState.nRed;
        CellState targetValueB = CellState.Red;
        int RedCount = _gameBoard.Cast<CellState>().Where(x => x == targetValueA || x == targetValueB).Count();
        targetValueA = CellState.nBlue;
        targetValueB = CellState.Blue;
        int BlueCount = _gameBoard.Cast<CellState>().Where(x => x == targetValueA || x == targetValueB).Count();
        if (RedCount + BlueCount == 25)
        {

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
