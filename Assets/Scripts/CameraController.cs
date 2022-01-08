using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Range(0.0001f, 3.0f)]
    public float speed = 0.1f;

    public DoorController doorController;
    
    private void Update()
    {
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0.0f, Input.GetAxis("Vertical") * speed);
        transform.Translate(velocity);

        float rotation = 0.0f;
        if (Input.GetKey(KeyCode.Q))
        {
            rotation -= 1.0f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotation += 1.0f;
        }

        transform.Rotate(0.0f, rotation, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HitPoint")
        {
            doorController.OpenDoor();
        }
    }

}
