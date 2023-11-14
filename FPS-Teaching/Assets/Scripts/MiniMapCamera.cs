using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    public Transform playerObject;


    void Update()
    {
        Vector3 newPostion = playerObject.position;
        newPostion.y = transform.position.y;
        transform.position = newPostion;
    }
}
