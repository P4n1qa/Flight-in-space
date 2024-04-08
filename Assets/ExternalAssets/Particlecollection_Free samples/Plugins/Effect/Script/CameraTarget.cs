using UnityEngine;

namespace ExternalAssets.Particlecollection_Free_samples.Plugins.Effect.Script
{
	[ExecuteInEditMode]
	public class CameraTarget : MonoBehaviour {
		public Transform m_TargetOffset;

		void LateUpdate(){
			transform.LookAt (m_TargetOffset);
		}

	}
}
