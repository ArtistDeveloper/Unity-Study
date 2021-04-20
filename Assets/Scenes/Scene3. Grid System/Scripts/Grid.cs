using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    //width와 hegith를 받을 수 있는 생성자를 만듬.
    public Grid(int height, int width, float cellSize) 
    {
        this.height = height; //4
        this.width = width; //2
        this.cellSize = cellSize; //셀 사이즈를 통해 각 인덱스를 땅위에 올리기 위한 WorldPosition을 계산할 수 있다.

        gridArray = new int[height, width];
        // Debug.Log(width + " " + height); // 제대로 Grid가 생성되는지 테스트

        for (int z = 0; z < gridArray.GetLength(0); z++)
        {
            for (int x = 0; x < gridArray.GetLength(1); x++) 
            {
                // Debug.Log(x + ", " + y); // grid배열의 값 확인

                UtilsClass.CreateWorldText(gridArray[z, x].ToString(), null, GetWorldPosition(z, x) + new Vector3(cellSize, 0, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(z, x), GetWorldPosition(z+1, x), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(z, x), GetWorldPosition(z, x+1), Color.white, 100f);
            }
            Debug.DrawLine(GetWorldPosition(height, 0), GetWorldPosition(height, width), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(0, width), GetWorldPosition(height, width), Color.white, 100f);
        }
    }

    //WorldPosition으로 변환시켜주는 작업.
    private Vector3 GetWorldPosition(int z, int x)
    {
        return new Vector3(x, 0, z) * cellSize;
    }

    public void SetValue(int x, int y, int SetValue) {
        
    }
} 
