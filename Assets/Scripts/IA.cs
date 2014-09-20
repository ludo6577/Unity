using UnityEngine;
using System.Collections;

public class IA : MonoBehaviour {

	public Transform targetPoint;
	public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		//agent.SetDestination(targetPoint.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = transform.position;
	}
}
