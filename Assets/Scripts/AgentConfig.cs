using UnityEngine;
using System.Collections;

public class AgentConfig : MonoBehaviour 
{
	public static float MaxRadius = 20;
	public static float MaxWeight = 300;

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
	public float WanderDistanceRadius;

	[Header("Vision")]
	[Tooltip("Unused")]
	public float MaxFieldOfViewAngle = 180;

	/// <summary>
	/// Randomizes the paramaters
	/// </summary>
	public void RandomizeSelf()
	{
		// Radius
		this.CohesionRadius = Random.Range(0, AgentConfig.MaxRadius);
		this.SeparationRadius = Random.Range(0, AgentConfig.MaxRadius);
		this.AllignmentRadius = Random.Range(0, AgentConfig.MaxRadius);
		this.WanderRadius = Random.Range(0, AgentConfig.MaxRadius);
		this.AvoidRadius = Random.Range(0, AgentConfig.MaxRadius);

		// Weights
		this.CohesionWeight = Random.Range(0, AgentConfig.MaxWeight);
		this.SeparationWeight = Random.Range(0, AgentConfig.MaxWeight);
		this.AllignmentWeight = Random.Range(0, AgentConfig.MaxWeight);
		this.WanderWeight = Random.Range(0, AgentConfig.MaxWeight);
		this.AvoidWeight = Random.Range(0, AgentConfig.MaxWeight);

		// Smooth Movement
		this.Jitter = Random.Range(0, AgentConfig.MaxWeight);
		this.WanderDistanceRadius = Random.Range(0, AgentConfig.MaxRadius);
	}
}
