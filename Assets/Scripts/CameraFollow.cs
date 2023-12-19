using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target = null;
    public Vector3 offset = Vector3.zero;
    
    private void LateUpdate(){
        
        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform);
    }
}
