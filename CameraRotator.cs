using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private TouchData _touchData;

    [SerializeField] private ToolSelecter _toolSelecter;

    [SerializeField] private float _speed = 0.5f;

    [SerializeField] private float _defaultYEulerAngles = -90f;

    private float _yRotation;

    private void Awake() => _yRotation = _defaultYEulerAngles;

    private void Update(){
        if(!_toolSelecter.Shoot){
            RotateCamera();
            ClampRotation();
        }
    }

    private void RotateCamera() => transform.Rotate(new Vector3(0, (_touchData.CurrentTouch.deltaPosition.x * _speed), 0), Space.World);

    private void ClampRotation(){
        _yRotation += (_touchData.CurrentTouch.deltaPosition.x * _speed);
        _yRotation = Mathf.Clamp(_yRotation, -120f, -60f);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, _yRotation, transform.rotation.eulerAngles.z);
    }
}
