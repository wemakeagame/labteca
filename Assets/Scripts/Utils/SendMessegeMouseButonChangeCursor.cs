﻿using UnityEngine;
using System.Collections;

public class SendMessegeMouseButonChangeCursor : MonoBehaviour 
{
	private Camera[] cameras;
	public GameObject target;
	public string message;

	public CursorMode cursorMode;
	public Texture2D cursor;

	private Ray ray;
	private RaycastHit hit;

	private bool inside = false;
	private bool insideLastFrame = false;

	// Use this for initialization
	void Start () 
	{
		cameras = FindObjectsOfType(typeof(Camera)) as Camera[];

		if (target == null) 
		{
			target = this.gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			cameras = FindObjectsOfType(typeof(Camera)) as Camera[];
			
			for (int i = 0; i < cameras.Length; i++) 
			{
				ray = cameras[i].ScreenPointToRay(Input.mousePosition);
				if(collider.Raycast(ray, out hit, 10000f))
				{
					target.SendMessage(message,SendMessageOptions.DontRequireReceiver);
				}
			}
		}



		inside = false;

		for (int i = 0; i < cameras.Length; i++) 
		{
			ray = cameras[i].ScreenPointToRay(Input.mousePosition);
			if(collider.Raycast(ray, out hit, 10000f))
			{
				Cursor.SetCursor(cursor,Vector2.zero,cursorMode);

				inside = true;
			}
		}

		if (insideLastFrame && !inside) 
		{
			Cursor.SetCursor(null,Vector2.zero,cursorMode);
		}

		insideLastFrame = inside;
	}
}
