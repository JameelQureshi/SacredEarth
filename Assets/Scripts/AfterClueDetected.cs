using UnityEngine;
using System.Collections;
using UnityEngine.Events;
namespace Vuforia
{
public class AfterClueDetected : MonoBehaviour,ITrackableEventHandler {
		private TrackableBehaviour mTrackableBehaviour;
        public UnityEvent OnTargetDetected;
        public UnityEvent OnTargetLost;
        // Use this for initialization
        void Start () {
			
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		    {
                OnTargetDetected.Invoke();
            }
		    else
		    {
                OnTargetLost.Invoke();
            }
        }
	}
}
