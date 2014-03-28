
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Edelweiss.DecalSystem;

namespace Edelweiss.DecalSystem.Example {
	
	public class collisionDetect : MonoBehaviour {

		public int decalsId = 0;
		public GameObject particlePrefab;
		public LayerMask layerMask;

		private Vector3 contactPoint;
		private bool hasCreateDecal = false;
		private GameObject collisionGameObject;
		private GameConttroller gameController;
		
		private void Start () {

			gameController = GameObject.FindWithTag("GameController").GetComponent<GameConttroller>();
		
		}
		
		private void Update () {			
			
			if (hasCreateDecal) {

				Vector3 viewPoint = Camera.main.WorldToViewportPoint(collisionGameObject.transform.position);
				Ray l_Ray = Camera.main.ViewportPointToRay (viewPoint);
				RaycastHit l_RaycastHit;

				if (Physics.Raycast (l_Ray, out l_RaycastHit, Mathf.Infinity,layerMask.value)) {

					gameObject.SetActive(false);

					DecalsController decalsController = collisionGameObject.GetComponent<DecalsController>();
		
					decalsController.AddDecalProjector(l_Ray, l_RaycastHit, contactPoint, decalsId);				

					GameObject explode = Instantiate(particlePrefab, contactPoint, transform.rotation) as GameObject;

					Invoke("ActivationGameObject", 0.5f);
					Destroy(explode, 5);

					hasCreateDecal = false;							
				}

			}
		}
		private void ActivationGameObject(){
			gameObject.SetActive(true);
		}		
	
		public void OnCollisionEnter(Collision collision){
			
			if(!hasCreateDecal){

				foreach (ContactPoint contact in collision.contacts) {
					contactPoint = contact.point;
					Debug.Log(gameObject.layer);
				}

				collisionGameObject = collision.gameObject;	

				gameController.StartMoveBackward();	

				hasCreateDecal = true;
			}		
		}
	}
}
