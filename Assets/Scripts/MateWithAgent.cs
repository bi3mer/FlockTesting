using UnityEngine;
using System.Collections;

public class MateWithAgent : MonoBehaviour 
{
	public int secondsToMate = 60;

	private int matingMultiplier = 1;
	private bool canMate = false;
	private AgentConfig config;
	private int startFrameCount;

	/// <summary>
	/// Start this instance with a thread running in background
	/// </summary>
	void Start()
	{
		// Start mating timer
		StartCoroutine(this.AllowToMate());

		// Get config
		this.config = this.GetComponent<AgentConfig>();

		// Get current frameCount
		this.startFrameCount = Time.frameCount;
	}

	/// <summary>
	/// Gets the multipler.
	/// </summary>
	/// <returns>The multipler.</returns>
	public int GetFrameLife()
	{
		return Time.frameCount - this.startFrameCount;
	}

	/// <summary>
	/// Allows to mate given certain times
	/// </summary>
	/// <returns>The to mate.</returns>
	private IEnumerator AllowToMate()
	{
		while(true)
		{
			yield return new WaitForSeconds(this.matingMultiplier * this.secondsToMate);

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
				                                     this.GetFrameLife(),
				                                     col.collider.GetComponent<AgentConfig>(),
				                                     col.collider.GetComponent<MateWithAgent>().GetFrameLife());
			}
		}
	}

	/// <summary>
	/// Raises the destroy event and ends coroutine
	/// </summary>
	void OnDestroy()
	{
		// Stop coroutine
		StopCoroutine(this.AllowToMate());
	}
}
