﻿using UnityEngine;
using System.Collections;

public class Idle : State {
	
	public Idle(GameObject go) : base(go){
		
	}
	
	public override void EnterState ()
	{
		
	}
	
	public override void Update (float dt)
	{
		Grazer grazer = gameObject.GetComponent<Grazer>();
		if(grazer.hunger > grazer.hunger_limit){
			grazer.sm.changeState(new Searching(gameObject));
		}
	}
	
	public override void ExitState ()
	{
		
	}
}
