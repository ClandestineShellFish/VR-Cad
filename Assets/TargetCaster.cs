using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCaster : MonoBehaviour
{
	[SerializeField] private Transform origin;
	[SerializeField] private LineRenderer lineRenderer;
	[SerializeField] private OVRInput.Button button;
	[SerializeField] private LayerMask layerMask;
	[SerializeField] private DataManager manager;
	private RaycastHit hit;

	private Vector3 OffsetOrigin => origin.position + origin.transform.forward * 0.05F;

	private void Update()
	{
		if (!Physics.Raycast(origin.position, origin.transform.forward, out hit, 100F, layerMask))
		{
			lineRenderer.SetPositions(new Vector3[] { OffsetOrigin, OffsetOrigin + 100F * origin.transform.forward });
			return;
		}

		lineRenderer.SetPositions(new Vector3[] { OffsetOrigin, hit.point });
		if (OVRInput.GetDown(button))
		{
			Debug.Log("Input: " + hit.point);
			manager.OnHandTrigger(hit.point);
		}
	}
}
