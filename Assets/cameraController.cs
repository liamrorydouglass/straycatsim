using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
	public GameObject target;
    public float damping = 1;
    public float shoulderAngle;

    Vector3 offset;
     
    void Start() {
        offset = target.transform.position - transform.position;
    }
     
    void LateUpdate() {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = target.transform.eulerAngles.y;

        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, damping);
         
        Quaternion rotation = Quaternion.Euler(0, angle - shoulderAngle, 0);
        transform.position = target.transform.position - (rotation * offset);
         
        transform.LookAt(target.transform);
    }
}
