using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _speedRotate;
    private Rigidbody _rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Rotate(0, -mouseX * _speedRotate * Time.deltaTime,0);
        }
    }


    // ANDROID CONTROL
    //private void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        if (touch.phase == TouchPhase.Moved)
    //        {
    //            float torque = touch.deltaPosition.x * Time.deltaTime * _speedRotate;
    //            _rb.AddTorque(Vector3.up * torque);
    //        }
    //    }
    //}
}
