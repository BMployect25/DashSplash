using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public Vector2 camMaxChange;
    public Vector2 camMinChange;

    public Vector3 playerChange;

    private CameraFollow cam;

    private void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Player")
        {
            TransitionRoom(other);
        }
    }

    private void TransitionRoom(Collider2D other)
    {
        cam.minPos += camMinChange;
        cam.maxPos += camMaxChange;

        other.transform.position += playerChange;
    }
}