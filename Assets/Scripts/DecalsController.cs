

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Edelweiss.DecalSystem;

namespace Edelweiss.DecalSystem.Example {
	
	public class DecalsController : MonoBehaviour {


		[SerializeField] public int [] decalsListA;
		[SerializeField] public int [] decalsListB;
		private int m_UVRectangleIndexA = 0;
		private int m_UVRectangleIndexB = 0;
		private int currentDecalsGrooupID = 0;
		[SerializeField] public int decalsId = 0;
		// The prefab with the ready to use DS_Decals. The material and uv rectangles are set up.
		[SerializeField] private DS_Decals m_DecalsPrefab = null;
		
		// The reference to the instantiated prefab's DS_Decals instance.
		private DS_Decals m_DecalsInstance;
		
		// We keep track of the projectors that we are creating at runtime. If we have more than
		// the maximum number of projectors, we remove the oldest ones.
		private List <DecalProjector> m_DecalProjectors = new List <DecalProjector> ();
		[SerializeField] private int m_MaximumNumberOfProjectors = 50;
		
		// We need a decals mesh and a cutter to create the decal projectors at runtime.
		private DecalsMesh m_DecalsMesh;
		private DecalsMeshCutter m_DecalsMeshCutter;
		
		// We can't place the projector exactly at the place where the raycast hits a collider. Instead,
		// it needs to be moved back, such that the projection looks believable. This value indicates how
		// many units the projector needs to be moved back.
		[SerializeField] private float m_DecalProjectorOffset = 0.5f;
		
		// The size, culling angle and mesh offset for the decal projectors for the bullets we are about to
		// create at runtime.
		[SerializeField] private Vector3 m_DecalProjectorScale = new Vector3 (0.2f, 2.0f, 0.2f);
		[SerializeField] private float m_CullingAngle = 80.0f;
		[SerializeField] private float m_MeshOffset = 0.0f;

		private int m_UVRectangleIndex = 0;	

		private void NextUVRectangleIndexA () {
			m_UVRectangleIndexA = m_UVRectangleIndexA + 1;
			if (m_UVRectangleIndexA >= decalsListA.Length) {
				m_UVRectangleIndexA = 0;
			}

			m_UVRectangleIndex = decalsListA[m_UVRectangleIndexA];
		}

		private void NextUVRectangleIndexB () {
			m_UVRectangleIndexB = m_UVRectangleIndexB + 1;
			if (m_UVRectangleIndexB >= decalsListB.Length) {
				m_UVRectangleIndexB = 0;

			}	

			m_UVRectangleIndex = decalsListB[m_UVRectangleIndexB];
		}
		
		private void Start () {
			
			// Instantiate the prefab and get its decals instance.
			m_DecalsInstance = Instantiate (m_DecalsPrefab) as DS_Decals;
			
			// Make sure the decals move with this dynamic object.
			m_DecalsInstance.transform.parent = transform;
			m_DecalsInstance.transform.localPosition = Vector3.zero;
			m_DecalsInstance.transform.localScale = Vector3.one;
			
			if (m_DecalsInstance == null) {
				Debug.LogError ("The decals prefab does not contain a DS_Decals instance!");
			} else {
				
				// Create the decals mesh and the cutter that are needed to compute the projections.
				m_DecalsMesh = new DecalsMesh (m_DecalsInstance);
				m_DecalsMeshCutter = new DecalsMeshCutter ();
			}
		}
		
		public void AddDecalProjector (Ray a_Ray, RaycastHit a_RaycastHit, Vector3 contactPoint, int decalsGroupID) {
			
			// Make sure there are not too many projectors.
			if (m_DecalProjectors.Count >= m_MaximumNumberOfProjectors) {
				
				// If there are more than the maximum number of projectors, we delete
				// the oldest one.
				DecalProjector l_DecalProjector = m_DecalProjectors [0];
				m_DecalProjectors.RemoveAt (0);
				m_DecalsMesh.RemoveProjector (l_DecalProjector);
			}
			
			// Calculate the position and rotation for the new decal projector.
			Vector3 l_ProjectorPosition = contactPoint - (m_DecalProjectorOffset * a_Ray.direction.normalized);
			Quaternion l_ProjectorRotation = ProjectorRotationUtility.ProjectorRotation (Camera.main.transform.forward, Vector3.up);
			
			// Randomize the rotation.
			Quaternion l_RandomRotation = Quaternion.Euler (0.0f, Random.Range (0.0f, 360.0f), 0.0f);
			l_ProjectorRotation = l_ProjectorRotation * l_RandomRotation;	
			
			// We hit a collider. Next we have to find the mesh that belongs to the collider.
			// That step depends on how you set up your mesh filters and collider relative to
			// each other in the game objects. It is important to have a consistent way in order
			// to have a simpler implementation.
			
			MeshCollider l_MeshCollider = a_RaycastHit.collider.GetComponent <MeshCollider> ();
			MeshFilter l_MeshFilter = a_RaycastHit.collider.GetComponent <MeshFilter> ();
			
			if (l_MeshCollider != null || l_MeshFilter != null) {
				Mesh l_Mesh = null;
				if (l_MeshCollider != null) {
					
					// Mesh collider was hit. Just use the mesh data from that one.
					l_Mesh = l_MeshCollider.sharedMesh;
				} else if (l_MeshFilter != null) {
					
					// Otherwise take the data from the shared mesh.
					l_Mesh = l_MeshFilter.sharedMesh;
				}
				
				if (l_Mesh != null) {

					if(decalsGroupID == 1){
						NextUVRectangleIndexA();
					} else {
						NextUVRectangleIndexB();
					}

					// Create the decal projector.
					DecalProjector l_DecalProjector = new DecalProjector (l_ProjectorPosition, l_ProjectorRotation, m_DecalProjectorScale, m_CullingAngle, m_MeshOffset, m_UVRectangleIndex, m_UVRectangleIndex);
				
					// Add the projector to our list and the decals mesh, such that both are
					// synchronized. All the mesh data that is now added to the decals mesh
					// will belong to this projector.
					m_DecalProjectors.Add (l_DecalProjector);
					m_DecalsMesh.AddProjector (l_DecalProjector);
					
					// Get the required matrices.
					Matrix4x4 l_WorldToMeshMatrix = a_RaycastHit.collider.renderer.transform.worldToLocalMatrix;
					Matrix4x4 l_MeshToWorldMatrix = a_RaycastHit.collider.renderer.transform.localToWorldMatrix;
					
					// Add the mesh data to the decals mesh, cut and offset it.
					m_DecalsMesh.Add (l_Mesh, l_WorldToMeshMatrix, l_MeshToWorldMatrix);						
					m_DecalsMeshCutter.CutDecalsPlanes (m_DecalsMesh);
					m_DecalsMesh.OffsetActiveProjectorVertices ();
					
					// The changes are only present in the decals mesh at the moment. We have
					// to pass them to the decals instance to visualize them.
					m_DecalsInstance.UpdateDecalsMeshes (m_DecalsMesh);

				}
			}
		}
	}
}