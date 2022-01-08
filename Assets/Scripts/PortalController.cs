using UnityEngine;
using UnityEngine.Rendering;

public class PortalController : MonoBehaviour
{

    public Material[] materials;
    public Transform device;

    private bool wasInFront;
    private bool inOtherWorld;
    private bool hasCollided;

    private void Start()
    {
        SetMaterials(false);
    }

    void SetMaterials(bool fullRender)
    {
        var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;
        Shader.SetGlobalInt("_StencilTest", (int)stencilTest);
    }

    private bool GetIsInFront()
    {
        Vector3 worldPos = device.position + (device.forward * Camera.main.nearClipPlane);
        Vector3 pos = transform.InverseTransformPoint(worldPos);

        return pos.z >= 0 ? true : false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform != device)
            return;

        wasInFront = GetIsInFront();
        hasCollided = true;
    }

    private void WhileCameraColliding()
    {
        if (!hasCollided)
            return;

        bool isInFront = GetIsInFront();
        if ((isInFront && !wasInFront) || (wasInFront && !isInFront))
        {
            inOtherWorld = !inOtherWorld;
            SetMaterials(inOtherWorld);
        }

        wasInFront = isInFront;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform != device)
            return;

        hasCollided = false;
    }

    private void OnDestroy()
    {
        SetMaterials(true);
    }

    private void LateUpdate()
    {
        WhileCameraColliding();
    }

}
