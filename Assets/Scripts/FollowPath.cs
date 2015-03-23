using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class FollowPath : MonoBehaviour {
	public Platform path;
	public float speed=5;
	public float maxDistanceTotal=0.2f;

	private IEnumerator<Transform>_currentPoint;
	// Use this for initialization
	void Start () {
		_currentPoint= path.GetPathEnumarator();
		_currentPoint.MoveNext();

		transform.position =_currentPoint.Current.position;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position= Vector3.MoveTowards (transform.position ,_currentPoint.Current.position,Time.deltaTime*speed);

		var distanceSquared = (transform.position-_currentPoint.Current.position).sqrMagnitude;
		if (distanceSquared <maxDistanceTotal *maxDistanceTotal){
			_currentPoint.MoveNext(); 
		}
	}
}
