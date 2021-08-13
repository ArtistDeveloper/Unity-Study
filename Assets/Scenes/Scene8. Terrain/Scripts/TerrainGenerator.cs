using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이를 Perlin Noise 또는 Terrain Generation이라 부를 수 있지만 여기선 터레인 생성으로 부름
public class TerrainGenerator : MonoBehaviour
{
    public int depth = 20;
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;


    Terrain terrain;

    private void Start()
    {
        // 매번 랜덤한 지형을 원하면
        offsetX = Random.Range(0f, 9999);
        offsetY = Random.Range(0f, 9999);
        terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    private void Update()
    {

    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height); // width, dept, height
        terrainData.SetHeights(0, 0, GenerateHeight()); // starting point : 0, 0,  
        return terrainData;
    }

    float[,] GenerateHeight()
    {

        float[,] heights = new float[width, height];
        // float형 그리드를 만들 수 있다.? 각 포인트는 맵이 가진 float와 연관있다.

        // 이제 부동 소수점 값을 Perlin nosie에서 어셈블하는 것과 동일하게 설정할 수 있는 각 지점을 반복합니다.

        // 각 포인트를 루프해보자
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);// SOME PELIN NOIS  E VALUE
            }
        }


        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        // 확대 및 축소할 수 있도록 이 두 값에 스케일을 곱한다는 것을 기억하십시오.

        // 우리는 좌표를 지정하고 이를 nosiemap 좌표로 변환하여 이를 수 행한 다음 해당 좌표에서 Perlin 노이즈 함수의 값을 반환합니다.
        float xCoord = (float)x / width * scale + offsetX; //(float)로 캐스팅해주지 않으면 값이 0이 나온다.
        float yCoord = (float)y / height * scale + offsetY;

        Debug.Log(xCoord);
        Debug.Log(yCoord);

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
