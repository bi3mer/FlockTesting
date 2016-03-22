using UnityEngine;
using System.Collections;

public class Predator : Agent
{
    void Start()
    {
        // Start with random velocity
        this.velocity = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));

        World.Instance.Predators.Add(this);
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
}
