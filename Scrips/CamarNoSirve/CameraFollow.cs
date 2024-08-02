using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
	public float smoothing;

	public Vector2 maxPos;
	public Vector2 minPos;

	private void FixedUpdated()
	{
		if(transform.position != target.position)
		{
			Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);
    			
			targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
			targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

		    transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
        
		}
	}
}
