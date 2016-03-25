using UnityEngine;
using System.Collections;

public class CreateBabyAgent : MonoBehaviour
{
	[Tooltip("Common Agent that can be Eaten")]
	public GameObject Agent;

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

		// TODO: Gentic stuff here with the config files
	}
}
