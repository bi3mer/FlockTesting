using UnityEngine;
using System.Collections;

public class AgentConfig : MonoBehaviour 
{
    // TODO: add line breaks in inspector and create better names
	[Header("Find Nearby Radius")]
    public float CohesionRadius;
    public float SeparationRadius;
    public float AllignmentRadius;
    public float WanderRadius;
    public float AvoidRadius;

	[Header("Weights for Given Behavior")]
    public float CohesionWeight;
    public float SeparationWeight;
    public float AllignmentWeight;
    public float WanderWeight;
    public float AvoidWeight;

	[Header ("Physics")]
    public float MaxAcceleration;
    public float MaxVelocity;

    [Header ("Smoothing Movement")]
    public float Jitter;
    public float WanderDistance;

	[Header ("Vision")]
	[Tooltip ("Unused")]
	public float MaxFieldOfViewAngle = 180;

	//TODO: implement
	public void RandomizeSelf()
	{

	}
}
