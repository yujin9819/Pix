using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCam : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float speed = 3f;
    public Vector2 offset;
    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;

    float cameraHalfWidth, cameraHalfHeight;

    void Start()
    {
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        cameraHalfHeight = Camera.main.orthographicSize;

    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(
            Mathf.Clamp(target.position.x + offset.x, minX + cameraHalfWidth, maxX - cameraHalfWidth),   // X
            Mathf.Clamp(target.position.y + offset.y, minY + cameraHalfHeight, maxY - cameraHalfHeight), // Y
            -10);                                                                                                  // Z
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * speed);
    }
}
