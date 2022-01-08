using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour
{
 
    private string TargetARFramework;

    private void Start()
    {
        TargetARFramework = "";
    }

    public void LoadTargetPlatformSpecificARScene()
    {
        string objectName = EventSystem.current.currentSelectedGameObject.name;

#if UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.WindowsEditor)
        {
            TargetARFramework = "ARCore";
        }

#elif UNITY_IOS
        if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            TargetARFramework = "ARKit";
        }
#endif

        SceneManager.LoadScene(TargetARFramework + " " + objectName);
    }

    public void LoadMenuARScene()
    {
        SceneManager.LoadScene("AR Selection");
    }

}
