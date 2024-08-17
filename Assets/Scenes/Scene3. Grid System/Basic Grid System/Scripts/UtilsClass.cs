using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilsClass
{
    public const int sortingOrderDefault = 5000;

    // World에 Text를 생성한다.
    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null
    , TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    // World에 Text를 생성한다.
    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color
    , TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        // Debug.Log("GameObject Transform : " + gameObject.transform.position); // position값은 자동으로 0, 0, 0으로 초기화 됨.

        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh)); // TextMesh컴포넌트를 가진 게임오브젝트 생성
        Transform transform = gameObject.transform; // 이 문장을 통해 gameObject.transform에 대한 레퍼런스가 transform 변수에 저장됨. (즉, 게임오브젝트 위치와 동기화)
        transform.SetParent(parent, false); //parent값이 null로 들어오면, 부모 게임오브젝트가 없음.
        transform.localPosition = localPosition; // WorldText게임오브젝트의 localPosition 정해주기
        transform.localEulerAngles = new Vector3(90, 0, 0); //숫자를 눕히려고 임의로 추가한 코드

        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
}
