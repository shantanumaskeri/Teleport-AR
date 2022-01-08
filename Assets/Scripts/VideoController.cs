using RenderHeads.Media.AVProVideo;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{

    private string sceneName;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    public void CheckCurrentSceneAndPlayVideo()
    {
        switch (sceneName)
        {
            case "ARKit 360 Video Portal":
            case "ARCore 360 Video Portal":
                GameObject.Find("Video Sphere").GetComponent<VideoPlayer>().enabled = true;
                break;

            case "ARKit Live Stream Portal":
            case "ARCore Live Stream Portal":
                GameObject.Find("Media Player").GetComponent<MediaPlayer>().enabled = true;
                break;
        }
    }

}
