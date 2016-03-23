using UnityEngine;
using System.Collections;

public class Predator : Agent
{
    void Start()
    {
        // Start with random velocity
        this.velocity = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
    }

    /// <summary>
    /// Use Allignment, Cohesion, and Separation to define behavior with diferent proportions based on importance
    /// </summary>
    /// <returns>Vector with correct behavior</returns>
    public override Vector2 Combine()
    {
        return AgentConfig.Instance.WanderWeight * base.Wander()
             + AgentConfig.Instance.CohesionWeight * base.Cohesion();
    }

	// Eat bird
	void OnCollisionEnter2D(Collision2D col) 
	{
		Debug.Log("Collisoin! " + col.gameObject.tag);
		// Check tag
		if(col.collider.transform.CompareTag("Agent"))
		{
			Debug.Log("Chomp!");
			// Eat prey
			Destroy(col.gameObject);
		}
	}
}
