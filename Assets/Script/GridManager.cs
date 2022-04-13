using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private int rows = 3;
    private int cols = 3;
    private float size = 6;

    public GameObject tile;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for(int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject obj = Instantiate(tile, transform);

                float posx = col * size;
                float posy = row * -size;

                obj.transform.position = new Vector2(posx, posy);
            }
        }

        float gridw = cols * size;
        float gridh = rows * size;
        transform.position = new Vector2(-gridw / 2 + size / 2, gridh / 2 - size / 2);
    }
}
