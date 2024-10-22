using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _following;

    public float RotationAngleX;
    public float Distance;
    public float offsetY;

    private Quaternion _rotation;

    private void Start()
    {
        _rotation = Quaternion.Euler(RotationAngleX, 0f, 0f);
        transform.rotation = _rotation;
    }


    private void LateUpdate()
    {
        if (_following == null)
            return;

        Vector3 position = _rotation * new Vector3(0, 0, -Distance) + FollowingPointPosition();
        position.x = transform.position.x;
        position.y = transform.position.y; 
        transform.position = position;
    }

    public void Follow(GameObject following) =>
        _following = following.transform;


    private Vector3 FollowingPointPosition()
    {
        Vector3 followingPosition = _following.position;
        followingPosition.y += offsetY;
        return followingPosition;
    }
}
