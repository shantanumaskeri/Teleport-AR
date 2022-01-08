using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public CanvasScaler canvasScaler;

    private void Start()
    {
        AdjustUIBasedOnScreenSize();
    }

    private void AdjustUIBasedOnScreenSize()
    {
        canvasScaler.gameObject.GetComponent<Canvas>().pixelPerfect = true;

        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        canvasScaler.referenceResolution = new Vector2(800, 600);
        canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        canvasScaler.referencePixelsPerUnit = 100;

#if UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor)
        {
            canvasScaler.matchWidthOrHeight = 1.0f;
        }

#elif UNITY_IOS
        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            canvasScaler.matchWidthOrHeight = 0.9f;
        }
#endif
    }
}
