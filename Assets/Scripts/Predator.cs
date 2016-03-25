using UnityEngine;
using System.Collections;

public class Predator : Agent
{
    void Start()
    {
        // Start with random velocity
        this.velocity = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));

		// Get configuration
		this.config = this.GetComponent<AgentConfig>();
    }

    /// <summary>
    /// Use Allignment, Cohesion, and Separation to define behavior with diferent proportions based on importance
    /// </summary>
    /// <returns>Vector with correct behavior</returns>
    public override Vector2 Combine()
    {
        return base.config.WanderWeight * base.Wander()
             + base.config.CohesionWeight * base.Cohesion();
    }
}
