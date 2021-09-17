using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Button mouseControlButton;
    [SerializeField] private Button keyboardMouseControlButton;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        switch (PlayerSettings.controlType)
        {
            case EControlType.Mouse:
                mouseControlButton.image.color = Color.green;
                keyboardMouseControlButton.image.color = Color.white;
                break;

            case EControlType.KeyboardMouse:
                mouseControlButton.image.color = Color.white;
                keyboardMouseControlButton.image.color = Color.green;
                break;
        }
    }

    public void SetControlMode(int controlType)
    {
        PlayerSettings.controlType = (EControlType)controlType;

        switch (PlayerSettings.controlType)
        {
            case EControlType.Mouse:
                mouseControlButton.image.color = Color.green;
                keyboardMouseControlButton.image.color = Color.white;
                break;

            case EControlType.KeyboardMouse:
                mouseControlButton.image.color = Color.white;
                keyboardMouseControlButton.image.color = Color.green;
                break;
        }
    }

    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("Close");
    }
}
