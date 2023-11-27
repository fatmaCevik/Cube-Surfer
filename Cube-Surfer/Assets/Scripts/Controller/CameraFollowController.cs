using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{/*
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        FollowCamera();
    }

    private void FollowCamera()
    {
        transform.localPosition = player.localPosition + offset;
    }
*/
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void Update()
    {
        if (target != null)
        {
             
            transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed * Time.deltaTime);

            //transform.LookAt(desiredPosition);
        }

    }
}
