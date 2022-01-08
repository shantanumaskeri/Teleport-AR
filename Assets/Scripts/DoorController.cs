using UnityEngine;

public class DoorController : MonoBehaviour
{

    public VideoController videoController;

    private bool isDoorOpen;

    private void Start()
    {
        isDoorOpen = false;
    }

    private void Update()
    {
        if (isDoorOpen)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(-90.0f, 0.0f, -90.0f)), 1.0f);
        }
    }

    public void OpenDoor()
    {
        isDoorOpen = true;

        LoadSceneVideo();
    }

    private void LoadSceneVideo()
    {
        if (videoController == null)
            return;

        videoController.CheckCurrentSceneAndPlayVideo();
    }

}
