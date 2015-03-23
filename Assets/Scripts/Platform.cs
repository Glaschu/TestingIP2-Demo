﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class Platform : MonoBehaviour {
	public Transform[] Points;

	public IEnumerator<Transform > GetPathEnumarator()
	{
		if(Points==null || Points.Length <1){
			yield break;
		}
		var direction=1;
		var index=0;
		while(true){
			yield return Points[index];
			if(Points.Length ==1){
				continue;
			}
			if(index<=0){
				direction = 1;
			}else if(index>=Points.Length-1){
				direction =-1;
			}
			index =index + direction;
		}


	}
	// Use this for initialization

	public void OnDrawGizmos(){
		if(Points==null || Points.Length <2){
			return;
		}

		for(var i =1;i<Points.Length;i++){
			Gizmos.DrawLine(Points[i-1].position,Points[i].position);
		}

	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawLine (start.position,end.position,Color.blue);
	}
}
