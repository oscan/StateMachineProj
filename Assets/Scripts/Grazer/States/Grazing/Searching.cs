using UnityEngine;
using System.Collections;

public class Searching : Grazing {
	
	bool pathing = false;
	float last_dist = 0f;
	
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
				if(hits.Length > 0) {
					foreach(Collider hit in hits){
						float d = Vector3.Distance(foodTarget.position, hit.gameObject.transform.position);
						if(d < nearest_dist && d > 0.75f){
							nearest_dist = d;
							Grass grass = hit.gameObject.GetComponent<Grass>();
							if(!grass.eaten){
								target = hit.gameObject;
							}
						}
					}
					if(target != null){
						pathing = true;
						gameObject.transform.LookAt(target.transform.position, Vector3.up);
						Vector3 ea = gameObject.transform.eulerAngles;
						ea.x = ea.z = 0;
						gameObject.transform.eulerAngles = ea;
						float new_d = Vector3.Distance(target.transform.position, foodTarget.position);
						last_dist = new_d;
						if(new_d < 0.75f){
							pathing = false;
							target = null;
						}
					}
				} else {
					//go to the herd
					
				}
			}
		} else {
			bool goahead = false;
			if(target != null) {
				float dist = Vector3.Distance(target.transform.position, foodTarget.position);
				if(dist > 0.75f) {
					goahead = true;
					gameObject.transform.Translate(gameObject.transform.forward*Time.deltaTime*Random.Range(0.9f,1.1f), Space.World);
					
					Debug.DrawLine(target.transform.position, foodTarget.position,Color.red);
					if(dist > last_dist) {
						//moving away
						pathing = false;	
						target = null;
					}
					last_dist = dist;
				}
			} 
			if(!goahead) {
				if(target != null){
					Grass grass = target.GetComponent<Grass>();
					if(!grass.eaten){
						grazer.sm.changeState(new Eating(gameObject, target));
					} else {
						pathing = false;
						target = null;
					}
				} else {
					pathing = false;
				}
			}
		}
	}
	
	public override void ExitState ()
	{
		
	}
}
