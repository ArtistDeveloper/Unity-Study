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
    public Grid(int width, int height, float cellSize) 
    {
        this.width = width; // 4
        this.height = height; // 2
        this.cellSize = cellSize; //셀 사이즈를 통해 각 인덱스를 땅위에 올리기 위한 WorldPosition을 계산할 수 있다.

        gridArray = new int[width, height];
        // Debug.Log(width + " " + height); // 제대로 Grid가 생성되는지 테스트

        for (int z = 0; z < gridArray.GetLength(0); z++)
        {
            for (int x = 0; x < gridArray.GetLength(1); x++) 
            {
                // Debug.Log(x + ", " + y); // grid배열의 값 확인

                // 첫 파라미터 : gridArray[x, y] => x행 y열의 값을 가져와서 String으로 바꿔준다.
                UtilsClass.CreateWorldText(gridArray[z, x].ToString(), null, GetWorldPosition(z, x), 20, Color.white, TextAnchor.MiddleCenter);
            }
        }
    }

    //WorldPosition으로 변환시켜주는 작업.
    private Vector3 GetWorldPosition(int z, int x)
    {
        return new Vector3(x, 0, z) * cellSize;
    }
} 
