using UnityEngine;
using UnityEngine.Networking;

public class CameraFollow : NetworkBehaviour
{
	public Transform playerTransform;
	private Vector3 velocity = Vector3.zero;


	// Update is called once per frame
	void Update()
	{

		if(playerTransform != null)
		{
			transform.position = Vector3.SmoothDamp (transform.position, playerTransform.position + new Vector3 (0, 40, 20), ref velocity, 0.3f);
		}
	}

	public void setTarget(Transform target)
	{
		
		playerTransform = target;
	}
}
