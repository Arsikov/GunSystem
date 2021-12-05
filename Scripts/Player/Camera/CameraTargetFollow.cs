using UnityEngine;

public class CameraTargetFollow : MonoBehaviour
{

    [SerializeField] private Transform Target;

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dirToMouse = mousePos - Target.position;
        transform.position = Target.position + new Vector3(dirToMouse.x * 0.3f, dirToMouse.y * 0.3f, -10);
    }

}