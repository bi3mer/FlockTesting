using UnityEngine;
using System.Collections;
using System;

public class CreateBabyAgent : MonoBehaviour
{
	[Tooltip("Common Agent that can be Eaten")]
	public GameObject Agent;

	[Tooltip("Value between 0-100")]
	public float MutationPercentage = 2;

	// Singleton
	private static CreateBabyAgent instance = null;
	public static CreateBabyAgent Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<CreateBabyAgent>();
			}
			return instance;
		}
	}

	/// <summary>
	/// Creates the baby agent using the frame lifes as a heuristic for how well it has performed, i.e. lifetime
	/// </summary>
	/// <param name="birthPosition">Birth position.</param>
	/// <param name="configOne">Config one.</param>
	/// <param name="frameLifeOne">Frame life one.</param>
	/// <param name="configTwo">Config two.</param>
	/// <param name="frameLifeTwo">Frame life two.</param>
	public void CreateChild(Vector2 birthPosition, AgentConfig configOne, int frameLifeOne, AgentConfig configTwo, int frameLifeTwo)
	{
		// Add to agents
		World.Instance.IncrementAgentCount();

		// Instantiate new agent
		GameObject agent = Instantiate(this.Agent, birthPosition, Quaternion.identity) as GameObject;

		// Get config of agent
		AgentConfig newConfig = agent.GetComponent<AgentConfig>();

		// Get likelihood of component one versus component two
		int componentLikeliHood = frameLifeOne / (frameLifeOne + frameLifeTwo);

		// Get fields of class
		System.Reflection.FieldInfo[] fields = newConfig.GetType().GetFields();

		// loop through fields
		for(int i = 0; i < fields.Length; ++i)
		{
			// Check field
			if(!fields[i].Name.Equals("MaxAcceleration") && !fields[i].Name.Equals("MaxVelocity"))
			{
				// create new value
				float newVal;

				// Check if gene will mutate
				if(UnityEngine.Random.Range(0, 100) < this.MutationPercentage)
				{
					// Check if a radius or weight
					if(fields[i].Name.Contains("Radius"))
					{
						newVal = UnityEngine.Random.Range(0, AgentConfig.MaxRadius);
					}
					else
					{
						newVal = UnityEngine.Random.Range(0, AgentConfig.MaxWeight);
					}
				}
				else
				{
					// pick new val based on percentage from other
					if(UnityEngine.Random.Range(0,100) / 100 > componentLikeliHood)
					{
						newVal = (float) fields[i].GetValue(configTwo);
					}
					else
					{
						newVal = (float) fields[i].GetValue(configOne);
					}
				}

				// set the value
				fields[i].SetValue(newConfig, newVal);
			}
		}
	}
}
