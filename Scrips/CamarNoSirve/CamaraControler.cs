using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControler : MonoBehaviour
{
    Transform Player;

    public float yDistance = 6f;
    public float yMovement = 12f;

    public float xDistance = 11f;
    public float xMovement = 22f;

    public Vector3 cameraOrigin;
    public Vector3 cameraDestination;

    public float movementTime = 0.5f;
    public bool isMoving;

    void star()
    {
        Player = FindObjectOfType<PlayerContoler>().transform;
    }

    void Update()
    {
        if(!isMoving)
        {
            if (Player.position.y - transform.position.y >= yDistance)
            {
                cameraDestination += new Vector3(0, yMovement, 0);
                StartCoroutine(MoveCamera());
            }
            else if (Player.position.y - transform.position.y >= yDistance)
            {
                cameraDestination -= new Vector3(0, yMovement, 0);
                StartCoroutine(MoveCamera());
            }
             else if (Player.position.x - transform.position.x >= xDistance)
            {
                cameraDestination += new Vector3(xMovement, 0, 0);
                StartCoroutine(MoveCamera());
            }
            else if (Player.position.x - transform.position.x >= xDistance)
            {
                 cameraDestination -= new Vector3(xMovement, 0, 0);
                StartCoroutine(MoveCamera());
            }
        }
    }

    IEnumerator MoveCamera()
    {
        isMoving = true;
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t+= Time.deltaTime / movementTime;
            transform.position = Vector3.Lerp(currentPos, cameraDestination, t);
            transform.position = new Vector3(transform.position.x, transform.position.y, currentPos.z);
            yield return null;
        }
        isMoving = false;
    }
}
