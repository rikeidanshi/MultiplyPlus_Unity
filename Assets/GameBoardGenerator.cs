using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardGenerator : MonoBehaviour
{
    public GameObject prefab;
    public int rows = 5;
    public int cols = 5;

   // Start is called before the first frame update
    private void Start()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject instance = Instantiate(prefab);

                Vector3 offset = CalculateOffset(row, col);

                float x = col * 1.0f + offset.x;
                float y = row * 1.0f + offset.y;
                float z = 0.0f;
                instance.transform.position = new Vector3(x, y, z);
                instance.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            }
        }
    }

    private Vector3 CalculateOffset(int row, int col)
    {
        float offsetX = (cols - 1) / 2.0f * -1.0f;
        float offsetY = (rows - 1) / 2.0f * -1.0f;
        return new Vector3(offsetX, offsetY, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
