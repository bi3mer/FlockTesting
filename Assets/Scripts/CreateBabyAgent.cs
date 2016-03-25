using UnityEngine;
using System.Collections;

public class CreateBabyAgent : MonoBehaviour
{
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
	/// Creates the baby agent using the multipliers as a heuristic for how well it has performed, i.e. lifetime
	/// </summary>
	/// <param name="birthPosition">Birth position.</param>
	/// <param name="configOne">Config one.</param>
	/// <param name="multiplierOne">Multiplier one.</param>
	/// <param name="configTwo">Config two.</param>
	/// <param name="multiplerTwo">Multipler two.</param>
	public void CreateChild(Vector2 birthPosition, AgentConfig configOne, int multiplierOne, AgentConfig configTwo, int multiplerTwo)
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
