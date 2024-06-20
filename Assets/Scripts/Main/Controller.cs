using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    private enum tarn
    {
        Red,
        Blue
    }
    private tarn _currentTarn = tarn.Red;

    public int CurrentTarn { get { return (int)_currentTarn; } }
    
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

    private bool isDifficultActive;

    private static int _redScore;
    public static int RedScore { get { return _redScore; } }

    private static int _blueScore;
    public static int BlueScore { get { return _blueScore; } }

    public void Pushed(int row, int col)
    {
        if (_currentTarn == tarn.Red)
        {
            if (_gameBoard[row, col] == CellState.Empty ^ (isDifficultActive && _gameBoard[row, col] == CellState.Red))
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
            if (_gameBoard[row, col] == CellState.Empty ^ (isDifficultActive && _gameBoard[row, col] == CellState.Blue))
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
        _redScore = _gameBoard.Cast<CellState>().Where(x => x == targetValueA || x == targetValueB).Count();
        targetValueA = CellState.nBlue;
        targetValueB = CellState.Blue;
        _blueScore = _gameBoard.Cast<CellState>().Where(x => x == targetValueA || x == targetValueB).Count();
        if (_redScore + _blueScore == 25)
        {
            SceneManager.LoadScene("ResultScene");
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        _redButtonManager = GameObject.Find("RedButtonManager").GetComponent<RedButtonManager>();
        _blueButtonManager = GameObject.Find("BlueButtonManager").GetComponent<BlueButtonManager>();
        _redScore = 0;
        _blueScore= 0;

        int firstAttack = TitleButtonManager.FirstAttack;
        if (firstAttack == 0) { _currentTarn = tarn.Red; }
        else if (firstAttack == 2) { _currentTarn = tarn.Blue; }
        else
        {
            _currentTarn = (tarn)(Random.Range(0, 2));
        }
        isDifficultActive = TitleButtonManager.IsDifficultActive;

        Destroy(GameObject.Find("ButtonManager"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
