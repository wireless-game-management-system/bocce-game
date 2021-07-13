using UnityEngine;
using System.Collections;

public class PlayerCameraController : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    
    public float minimumX = -360F;
    public float maximumX = 360F;
    
    public float minimumY = -60F;
    public float maximumY = 60F;
    
    float rotationX = 0F;
    float rotationY = 0F;
    
    Quaternion originalRotation;
    
    void Start()
    {
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
        originalRotation = transform.localRotation;
    }
    
    void Update()
    {
        // skip if paused
        if (BocceGame.Paused || Cursor.lockState == CursorLockMode.None)
            return;
    
        if (axes == RotationAxes.MouseXAndY)
        {
            // Read the mouse input axis
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);
            
            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        } else if (axes == RotationAxes.MouseX)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationX = ClampAngle(rotationX, minimumX, maximumX);
            
            Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        } else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = ClampAngle(rotationY, minimumY, maximumY);
            
            Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }
    
    void OnEnable()
    {
        transform.localRotation = originalRotation;
    }
    
    void OnDisable()
    {
        transform.localRotation = originalRotation;
    }
    
    public static float ClampAngle(float angle_, float min_, float max_)
    {
        if (angle_ < -360F)
            angle_ += 360F;
        if (angle_ > 360F)
            angle_ -= 360F;
        return Mathf.Clamp(angle_, min_, max_);
    }
}
