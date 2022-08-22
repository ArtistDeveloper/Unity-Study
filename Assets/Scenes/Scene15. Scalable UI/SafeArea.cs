using System;
using UnityEngine;

/// <summary>
/// 노치가 있는 모바일 장치에 대한 safe area구현. 사용법:
///  (1) 이 컴포넌트를 GUI 패널의 최상위 level에 추가합니다.
///  (2) If the panel uses a full screen background image, then create an immediate child and put the component on that instead, with all other elements childed below it.
///      This will allow the background image to stretch to the full extents of the screen behind the notch, which looks nicer.
///  (3) For other cases that use a mixture of full horizontal and vertical background stripes, use the Conform X & Y controls on separate elements as needed.
/// </summary>
public class SafeArea : MonoBehaviour
{
    #region Simulations
    /// <summary>
    /// Simulation device that uses safe area due to a physical notch or software home bar. For use in Editor only.
    /// </summary>
    public enum SimDevice
    {
        // Don't use a simulated safe area - GUI will be full screen as normal.
        None,

        // Simulate the iPhone X and Xs (identical safe areas).
        iPhoneX,

        // Simulate the iPhone Xs Max and XR (identical safe areas).
        iPhoneXsMax
    }


    // 편집기에서만 사용하기 위한 시뮬레이션 모드입니다. 이것은 다른 안전 영역 사이를 토글하기 위해 런타임에 편집할 수 있습니다.
    public static SimDevice sim = SimDevice.None;

    /// <summary>
    /// 홈 표시기가 있는 iPhoneX에 대해서 표준화된 safe area (비율은 iPhoneXs와 동일하다).
    /// safe area를 print해보면 "Rect(0.00, 102.00, 1125, 2202)"가 출력된다.
    ///  PortraitU x=0, y=102, w=1125, h=2202 on full extents w=1125, h=2436;
    ///  PortraitD x=0, y=102, w=1125, h=2202 on full extents w=1125, h=2436 (not supported, remains in Portrait Up);
    ///  LandscapeL x=132, y=63, w=2172, h=1062 on full extents w=2436, h=1125;
    ///  LandscapeR x=132, y=63, w=2172, h=1062 on full extents w=2436, h=1125.
    ///  Aspect Ratio: ~19.5:9.
    ///  Rect : x, y, width, height // x와 y는 Rect가 시작될 position을 의미한다.
    /// </summary>
    protected Rect[] NSA_iPhoneX = new Rect[]
    {
            new Rect (0f, 102f / 2436f, 1f, 2202f / 2436f),  // Portrait, 0 ~ 1사이의 비율 구하기 위해 나눔.
            new Rect (132f / 2436f, 63f / 1125f, 2172f / 2436f, 1062f / 1125f)  // Landscape
    };

    /// <summary>
    /// Normalised safe areas for iPhone Xs Max with Home indicator (ratios are identical to iPhone XR). Absolute values:
    ///  PortraitU x=0, y=102, w=1242, h=2454 on full extents w=1242, h=2688;
    ///  PortraitD x=0, y=102, w=1242, h=2454 on full extents w=1242, h=2688 (not supported, remains in Portrait Up);
    ///  LandscapeL x=132, y=63, w=2424, h=1179 on full extents w=2688, h=1242;
    ///  LandscapeR x=132, y=63, w=2424, h=1179 on full extents w=2688, h=1242.
    ///  Aspect Ratio: ~19.5:9.
    /// </summary>
    protected Rect[] NSA_iPhoneXsMax = new Rect[]
    {
        new Rect (0f, 102f / 2688f, 1f, 2454f / 2688f),  // Portrait
        new Rect (132f / 2688f, 63f / 1242f, 2424f / 2688f, 1179f / 1242f)  // Landscape
    };

    #endregion

    public static Rect CurrentSA; // 현재 safe area
    public static Action OnUpdate;

    protected RectTransform Panel;

    protected Rect LastSafeArea = new Rect(0, 0, 0, 0);

    [SerializeField] bool ConformX = true; // X축의 화면 안전 영역 준수(기본값은 true, 무시하려면 비활성화)
    [SerializeField] bool ConformY = true; // Y축의 화면 안전 영역 준수(기본값은 true, 무시하려면 비활성화)


    private void Awake()
    {
        Panel = GetComponent<RectTransform>();

        if (Panel == null)
        {
            Debug.LogError("safe area를 적용할 수 없습니다. -RectTransform을 찾을 수 없음." + name);
            Destroy(gameObject);
        }

        Refresh();
    }

    private void Update()
    {
        Refresh();
    }

    private void Refresh()
    {
        Rect safeArea = GetSafeArea();

        if (safeArea != LastSafeArea)
        {
            ApplySafeArea(safeArea);
        }
    }


    /// <summary>
    /// 모바일 장치의 안전 영역을 가져옵니다. 편집기에서 실행 중인 경우 시뮬레이션 영역을 가져옵니다.
    /// </summary>
    /// <returns>The safe area.</returns>
    private Rect GetSafeArea()
    {
        Rect safeArea = Screen.safeArea;

#if UNITY_EDITOR
        if (Application.isEditor && sim != SimDevice.None)
        {
            Rect nsa = new Rect(0, 0, Screen.width, Screen.height); // no safe area. 즉, 화면 전체의 크기 iphoneX는 0, 0, 1125, 2436이다.

            switch (sim)
            {
                case SimDevice.iPhoneX:
                    if (Screen.height > Screen.width)  // Portrait
                        nsa = NSA_iPhoneX[0];
                    else  // Landscape
                        nsa = NSA_iPhoneX[1];
                    break;
                case SimDevice.iPhoneXsMax:
                    if (Screen.height > Screen.width)  // Portrait
                        nsa = NSA_iPhoneXsMax[0];
                    else  // Landscape
                        nsa = NSA_iPhoneXsMax[1];
                    break;
                default:
                    break;
            }

            safeArea = new Rect(Screen.width * nsa.x, Screen.height * nsa.y, Screen.width * nsa.width, Screen.height * nsa.height);
        }
#endif

        CurrentSA = safeArea;

        return safeArea;
    }

    /// <summary>
    /// safe area를 적용합니다.
    /// anchor의 min과 max값을 제한하는 방식으로 safe area를 확보합니다.
    /// </summary>
    /// <param name="r">The safe area.</param>
    protected virtual void ApplySafeArea(Rect r)
    {
        LastSafeArea = r;

        // Ignore x-axis?
        if (!ConformX)
        {
            r.x = 0;
            r.width = Screen.width;
        }

        // Ignore y-axis?
        if (!ConformY)
        {
            r.y = 0;
            r.height = Screen.height;
        }

        // Convert safe area rectangle from absolute pixels to normalised anchor coordinates
        // safe area rectangle을 절대 픽셀에서 정규화된 앵커 좌표로 변환
        Debug.Log("r.position : " + r.position);
        Debug.Log("r.size : " + r.size);

        Vector2 anchorMin = r.position; // iPhoneX 기준으로 "0.0, 102.0"의 값을 가집니다. safe area의 starting position를 가리킵니다. 
        Vector2 anchorMax = r.position + r.size; // safe area starting position에 safe area의 size만큼 더하면 safe area의 값이 나옵니다.
        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;
        Panel.anchorMin = anchorMin;
        Panel.anchorMax = anchorMax;

        OnUpdate?.Invoke();
    }
}
