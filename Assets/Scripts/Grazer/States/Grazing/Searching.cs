using UnityEngine;
using System.Collections;

public class Searching : Grazing {
	
	bool pathing = false;
	
	public Searching(GameObject go) : base(go){
		
	}
	
	public override void EnterState ()
	{
		
	}
	
	public override void Update (float dt)
	{
		if(!pathing) {
		//search
			if(foodTarget != null && grazer != null){
				target = null;
				Collider[] hits = Physics.OverlapSphere(foodTarget.position, 8f, grazer.foodMask);
				float nearest_dist = Mathf.Infinity;
				Debug.Log(hits.Length);
				foreach(Collider hit in hits){
					float d = Vector3.Distance(foodTarget.position, hit.gameObject.transform.position);
					if(d < nearest_dist){
						nearest_dist = d;
						target = hit.gameObject;
					}
				}
				if(target != null){
					pathing = true;
					gameObject.transform.LookAt(target.transform.position, Vector3.up);
				}
			}
		} else {
			float dist = Vector3.Distance(target.transform.position, foodTarget.position);
			if(dist > 0.5f) {
				gameObject.transform.Translate(gameObject.transform.forward*Time.deltaTime, Space.World);
			} else {
				grazer.sm.changeState(new Eating(gameObject, target));
			}
		}
	}
	
	public override void ExitState ()
	{
		
	}
}
