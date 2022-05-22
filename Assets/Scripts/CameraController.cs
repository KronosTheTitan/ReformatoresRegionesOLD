using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public float panSpeed = 20f;
    public Vector2 panLimit;

    public float minY = 20f;
    public float maxY = 120f;

    public float minAngle = 45f;
    public float maxAngle = 90f;

    public float scrollSpeed = 2f;

    private void Start()
    {
        if (instance != null) Destroy(instance.gameObject);
        instance = this;
    }
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        transform.position = pos;
        float rot = minAngle+((maxAngle - minAngle)*((transform.position.y-minY)/(maxY-minY)));
        var rotation = transform.rotation;
        rotation = Quaternion.Euler(rot,rotation.y,rotation.z);
        transform.rotation = rotation;
    }
}
