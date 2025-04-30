using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private Vector3 target;
    private Camera cam;

    private void Start()
    {
        target = this.transform.position;
        cam = GetComponent<Camera>();
        GameManager.SetComponent(this);
    }

    private void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target, 0.05f);
    }

    public void UpPos()
    {
        target = this.transform.position + (Vector3.up * 0.1f);
    }

    public void ChangeColor()
    {
        cam.backgroundColor = Color.white;
    }
}
