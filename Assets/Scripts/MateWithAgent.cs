using UnityEngine;
using System.Collections;

public class MateWithAgent : MonoBehaviour 
{
	private int matingMultiplier = 1;
	private bool canMate = false;
	private int secondsInAMinute = 60;
	private AgentConfig config;

	/// <summary>
	/// Start this instance with a thread running in background
	/// </summary>
	void Start()
	{
		// Start mating timer
		StartCoroutine(this.AllowToMate());

		// Get config
		this.config = this.GetComponent<AgentConfig>();
	}

	/// <summary>
	/// Gets the multipler.
	/// </summary>
	/// <returns>The multipler.</returns>
	public int GetMultipler()
	{
		return this.matingMultiplier;
	}

	/// <summary>
	/// Allows to mate given certain times
	/// </summary>
	/// <returns>The to mate.</returns>
	private IEnumerator AllowToMate()
	{
		while(true)
		{
			yield return new WaitForSeconds(this.matingMultiplier * this.secondsInAMinute);

			// Incrmenet and allow agent to mate
			++this.matingMultiplier;
			this.canMate = true;
		}
	}

	/// <summary>
	/// Raises the collision enter2d event and mate with the other agent.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D(Collision2D col) 
	{
		if(this.canMate)
		{
			// Can no longer mater
			this.canMate = false;

			// Check tag
			if(col.collider.transform.CompareTag("Agent"))
			{
				// Create child at position with configs
				CreateBabyAgent.Instance.CreateChild(this.transform.position, 
				                                     this.config,
				                                     this.matingMultiplier,
				                                     col.collider.GetComponent<AgentConfig>(),
				                                     col.collider.GetComponent<MateWithAgent>().GetMultipler());
			}
		}
	}

	/// <summary>
	/// Raises the destroy event and ends coroutine
	/// </summary>
	void OnDestroy()
	{
		// Decrement agent count
		World.Instance.DecrementAgentCount();

		// Stop coroutine
		StopCoroutine(this.AllowToMate());
	}
}
