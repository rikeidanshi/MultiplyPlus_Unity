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
        Blue,
        Waiting
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
        StartCoroutine(CellChange(row, col));
    }

    private IEnumerator CellChange(int row, int col)
    {
        if (_currentTarn == tarn.Red)
        {
            _currentTarn = tarn.Waiting;
            if (_gameBoard[row, col] == CellState.Empty ^ (isDifficultActive && _gameBoard[row, col] == CellState.Red))
            {
                _gameBoard[row, col] = CellState.nRed;

                int Direction = _redButtonManager.GetValue();
                if (Direction == 0)
                {
                    bool[] bools = new bool[4];
                    for (int i = 1; i <= 4; i++)
                    {
                        if (row + i <= 4)
                        {
                            if (_gameBoard[row + i, col] != CellState.nRed)
                            {
                                _gameBoard[row + i, col] = CellState.Red;
                            }
                        }
                        else
                        {
                            bools[0] = true;
                        }
                        if (row - i >= 0)
                        {
                            if (_gameBoard[row - i, col] != CellState.nRed)
                            {
                                _gameBoard[row - i, col] = CellState.Red;
                            }
                        }
                        else
                        {
                            bools[1] = true;
                        }
                        if (col + i <= 4)
                        {
                            if (_gameBoard[row, col + i] != CellState.nRed)
                            {
                                _gameBoard[row, col + i] = CellState.Red;
                            }
                        }
                        else
                        {
                            bools[2] = true;
                        }
                        if (col - i >= 0)
                        {
                            if (_gameBoard[row, col - i] != CellState.nRed)
                            {
                                _gameBoard[row, col - i] = CellState.Red;
                            }
                        }
                        else
                        {
                            bools[3] = true;
                        }
                        if (bools.All(b => b))
                        {
                            break;
                        }
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                else
                {
                    bool[] bools = new bool[4];
                    for (int i = 1; i <= 4; i++)
                    {
                        if (row + i <= 4 && col + i <= 4)
                        {
                            if (_gameBoard[row+i, col+i] != CellState.nRed)
                            {
                                _gameBoard[row+i, col+i] = CellState.Red;
                            }
                        }
                        else
                        {
                            bools[0] = true;
                        }
                        if (row - i >= 0 && col + i <= 4)
                        {
                            if (_gameBoard[row-i, col+i] != CellState.nRed)
                            {
                                _gameBoard[row-i, col+i] = CellState.Red;
                            }
                        }
                        else
                        {
                            bools[1] = true;
                        }
                        if (row + i <= 4 && col - i >= 0)
                        {
                            if (_gameBoard[row+i, col-i] != CellState.nRed)
                            {
                                _gameBoard[row+i, col-i] = CellState.Red;
                            }
                        }
                        else
                        {
                            bools[2] = true;
                        }
                        if (row - i >= 0 && col - i >= 0)
                        {
                            if (_gameBoard[row - i, col - i] != CellState.nRed)
                            {
                                _gameBoard[row - i, col - i] = CellState.Red;
                            }
                        }
                        else
                        {
                            bools[3] = true;
                        }
                        if (bools.All(b => b))
                        {
                            break;
                        }
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                TarnEnd();
                _currentTarn = tarn.Blue;
            }
        }
        else if (_currentTarn == tarn.Blue)
        {
            _currentTarn = tarn.Waiting;
            if (_gameBoard[row, col] == CellState.Empty ^ (isDifficultActive && _gameBoard[row, col] == CellState.Blue))
            {
                _gameBoard[row, col] = CellState.nBlue;

                int Direction = _blueButtonManager.GetValue();
                if (Direction == 0)
                {
                    bool[] bools = new bool[4];
                    for (int i = 1; i <= 4; i++)
                    {
                        if (row + i <= 4)
                        {
                            if (_gameBoard[row + i, col] != CellState.nBlue)
                            {
                                _gameBoard[row + i, col] = CellState.Blue;
                            }
                        }
                        else
                        {
                            bools[0] = true;
                        }
                        if (row - i >= 0)
                        {
                            if (_gameBoard[row - i, col] != CellState.nBlue)
                            {
                                _gameBoard[row - i, col] = CellState.Blue;
                            }
                        }
                        else
                        {
                            bools[1] = true;
                        }
                        if (col + i <= 4)
                        {
                            if (_gameBoard[row, col + i] != CellState.nBlue)
                            {
                                _gameBoard[row, col + i] = CellState.Blue;
                            }
                        }
                        else
                        {
                            bools[2] = true;
                        }
                        if (col - i >= 0)
                        {
                            if (_gameBoard[row, col - i] != CellState.nBlue)
                            {
                                _gameBoard[row, col - i] = CellState.Blue;
                            }
                        }
                        else
                        {
                            bools[3] = true;
                        }
                        if (bools.All(b => b))
                        {
                            break;
                        }
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                else
                {
                    bool[] bools = new bool[4];
                    for (int i = 1; i <= 4; i++)
                    {
                        if (row + i <= 4 && col + i <= 4)
                        {
                            if (_gameBoard[row + i, col + i] != CellState.nBlue)
                            {
                                _gameBoard[row + i, col + i] = CellState.Blue;
                            }
                        }
                        else
                        {
                            bools[0] = true;
                        }
                        if (row - i >= 0 && col + i <= 4)
                        {
                            if (_gameBoard[row - i, col + i] != CellState.nBlue)
                            {
                                _gameBoard[row - i, col + i] = CellState.Blue;
                            }
                        }
                        else
                        {
                            bools[1] = true;
                        }
                        if (row + i <= 4 && col - i >= 0)
                        {
                            if (_gameBoard[row + i, col - i] != CellState.nBlue)
                            {
                                _gameBoard[row + i, col - i] = CellState.Blue;
                            }
                        }
                        else
                        {
                            bools[2] = true;
                        }
                        if (row - i >= 0 && col - i >= 0)
                        {
                            if (_gameBoard[row - i, col - i] != CellState.nBlue)
                            {
                                _gameBoard[row - i, col - i] = CellState.Blue;
                            }
                        }
                        else
                        {
                            bools[3] = true;
                        }
                        if (bools.All(b => b))
                        {
                            break;
                        }
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                TarnEnd();
                _currentTarn = tarn.Red;
            }
        }
        yield return null;
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
