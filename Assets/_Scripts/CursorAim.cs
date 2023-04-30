using System;
using UnityEngine;

public class CursorAim : MonoBehaviour
{
    [SerializeField] private Transform _aimObject;
    private Camera _mainCam;

    private void Start()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        Vector3 cursorDirection = GetCursorDirection();
        float angle = Mathf.Atan2(cursorDirection.y, cursorDirection.x) * Mathf.Rad2Deg;
        _aimObject.localRotation = Quaternion.Euler(0, 0, angle);
    }

    private Vector3 GetCursorDirection()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mousePosition = _mainCam.ScreenToWorldPoint(mouseScreenPosition);
        return mousePosition - transform.position;
    }
}