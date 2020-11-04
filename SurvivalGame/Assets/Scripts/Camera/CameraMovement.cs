using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    [Range (0f,1f)][SerializeField] private float smooth;

    private void FixedUpdate()
    {
        if (target.position != transform.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smooth);
        }
    }
}
