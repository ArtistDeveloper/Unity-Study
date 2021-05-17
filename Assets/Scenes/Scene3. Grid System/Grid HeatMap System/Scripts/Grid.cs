using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GridHeatMap
{
    public class Grid
    {
        private int width;
        private int height;
        private float cellSize;
        private Vector3 originPosition; //Grid의 시작점이 [0,0]이 아닐수도 있어서 사용하는 변수.
        private int[,] gridArray;
        private TextMesh[,] debugTextArray;

        public Grid(int width, int height, float cellSize, Vector3 originPosition)
        {
            this.width = width; //4
            this.height = height; //2
            this.cellSize = cellSize; //셀 사이즈를 통해 각 인덱스를 땅위에 올리기 위한 WorldPosition을 계산할 수 있다.
            this.originPosition = originPosition;

            gridArray = new int[width, height];
            debugTextArray = new TextMesh[width, height]; //World에 뜨는 숫자

            //
            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int z = 0; z < gridArray.GetLength(1); z++)
                {
                    debugTextArray[x, z] = UtilsClass.CreateWorldText(gridArray[x, z].ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize, 0, cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
                }
                Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
            }
            // SetValue(2, 1, 56); //혹시 NullReference가 난다면, TextMesh값이 debugTextArray에 들어가지 않아서 그런 것.
        }

        //Gird셀의 위치들을 WorldPosition으로 변환시켜주는 작업. 
        private Vector3 GetWorldPosition(int x, int z)
        {
            return new Vector3(x, 0, z) * cellSize + originPosition;
        }

        //좌표에 따른 Grid x,y값 반환. Point를 담은 struct를 반환해도 되겠지만 여기서는 out을 사용해봄.
        private void GetXZ(Vector3 worldPosition, out int x, out int z)
        {
            x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize); //FlootToTint : 버림함수
            z = Mathf.FloorToInt((worldPosition - originPosition).z / cellSize);
        }

        public void SetValue(int x, int z, int value)
        {
            //x, y값이 유효한지 확인 (invalid한 값이면 잠재적 에러 요소임.) 여기서는 x, z값
            if ((x >= 0) && (z >= 0) && (x < width) && (z < height))
            {
                gridArray[x, z] = value; //1행 2열
                debugTextArray[x, z].text = gridArray[x, z].ToString();
            }
        }

        //x, y가 아닌 worldPositon을 받는 SetValue함수
        public void SetValue(Vector3 worldPosition, int value)
        {
            int x, z;
            GetXZ(worldPosition, out x, out z);
            SetValue(x, z, value);
        }

        public int GetValue(int x, int z)
        {
            if ((x >= 0) && (z >= 0) && (x < width) && (z < height))
                return gridArray[x, z];
            else
                return -1;
        }

        public int GetValue(Vector3 worldposition)
        {
            int x, z;
            GetXZ(worldposition, out x, out z);
            return GetValue(x, z);
        }
    }
}
