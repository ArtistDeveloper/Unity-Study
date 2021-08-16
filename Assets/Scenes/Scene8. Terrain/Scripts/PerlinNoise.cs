using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    // 텍스처 : 가로, 세로 256픽셀
    public int width = 256;
    public int height = 256;

    /// <summary>
    /// 우리는 이것을 하나의 척도라고 부를 것입니다. 그리고 우리는 20과 같은 것으로 기본 설정할 수 있습니다. 그리고 우리는 눈금을 곱해서 우리의 색을 계산할 것입니다.
    /// 그래서 이것은 우리의 전체 좌표 숫자를 위아래로 스케일링 할 것입니다. 만약 우리의 스케일이 20이 된다면 우리의 좌표가 더 커질 것이고, 따라서 우리의 펄린 노이즈를 질감에 더 많이 주입할 것입니다.
    /// </summary>
    public float scale = 20f;
    public float offsetX = 100f;
    public float offsetY = 100f;

    /// <summary>
    /// 매터리얼의 디폴트 텍스처를 변경하기 위해 현재 렌더러의 참조를 가져와야 한다. 
    /// 메쉬 렌더러 컴포넌트에 접근한 다음, 텍스처를 변경한다.
    /// </summary>

    private void Start()
    {
        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);
    }

    private void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenereateTexture();
    }

    Texture2D GenereateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        // 이렇게 생성하는 것은 매우크고, 비효율적이다. 그래서 펄린 노이즈르 사용한다.
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply(); // texture 적용 잊지말기.
        return texture;
    }


    /// <summary>
    /// Perlin noise로 계산하여 랜덤한 값을 만들어낸다.
    /// 주의해야할 점은 x, y를 sample에 넣는데, 픽셀좌표계인 x, y로 값을 넣고있다.
    /// 그래서 우리는 이것을 0에서 256으로 가는 대신 소수점 이하 자릿수로 바꾸는 것을 원합니다. 0에서 1로 갈 수 있습니다.
    /// 이 뚜껑이 화소든 아니든 우린 1/2이나 0.3 화소를 상대하지 않아요
    /// 펄린 소음은 실제로 정수에서 반복되기 때문에 펄린 소음 기능에 큰 도움이 되지 않습니다.
    /// 0에서 256으로 가는 대신 0에서 1로 가는 것으로 바꾸는 것이 좋다.
    /// </summary>
    Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord); // 정수값이 들어가게 되면,일정한 값 밖에 나오지 않는다.
        return new Color(sample, sample, sample);
    }
}
