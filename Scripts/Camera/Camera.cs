using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private float _smooth = 5.0f;
    private Vector3 _offset = new Vector3(0, 7, 0);

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _smooth);
    }
}
