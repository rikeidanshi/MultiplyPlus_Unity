using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    [SerializeField] float th = 2.0f;
    private float _startTime;
    private float _leftTime;

    private void GoOpening()
    {
        SceneManager.LoadScene("OpeningScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        _startTime = 0;
        _leftTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startTime = Time.time;
        }

        if (Input.GetMouseButton(0))
        {
            _leftTime = Time.time - _startTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_leftTime >= th)
            {
                GoOpening();
            }
            else
            {
                _startTime = 0;
            }
        }

        if (_leftTime >= th)
        {
            _startTime = 0;
            GoOpening();
        }
    }
}
