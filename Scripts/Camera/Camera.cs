using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float smooth = 5.0f;
    private Vector3 offset = new Vector3(0, 7, 0);

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth);
    }
}
