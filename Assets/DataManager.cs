using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
	private List<Vector3> points = new List<Vector3>();
	[SerializeField] private LineRenderer lineRenderer;

	public void OnHandTrigger(Vector3 point)
	{
		points.Add(point);
		lineRenderer.positionCount = points.Count;
		lineRenderer.SetPositions(points.ToArray());
	}
}
