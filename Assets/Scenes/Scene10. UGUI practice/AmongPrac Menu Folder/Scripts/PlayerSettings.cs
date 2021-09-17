using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EControlType
{
    Mouse,
    KeyboardMouse
}


/// <summary>
/// 플레이어의 설정을 저장할 클래스
/// </summary>
public class PlayerSettings
{
    public static EControlType controlType;
}

