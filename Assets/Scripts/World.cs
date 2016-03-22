using UnityEngine;
using System.Collections.Generic;

public class World : MonoBehaviour
{
    public GameObject AgentPrefab;
    public int NumberOfAgents;

    public Vector2 ScreenBounds;
    public float SpawnRadius;

    [HideInInspector]
    public List<Agent> Agents;

    [HideInInspector]
    public List<Predator> Predators;

    private static World instance = null;
    public static World Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<World>();
            }
            return instance;
        }
    }

    void Start()
    {
        this.Agents = new List<Agent>();
        Spawn(AgentPrefab, this.NumberOfAgents);
    }

    /// <summary>
    /// Spawn Agents given a size and prefab
    /// </summary>
    /// <param name="position"></param>
    /// <param name="n"></param>
    public void Spawn(GameObject agentPrefab, int n)
    {
        // loop through n agents to spawn
        for (int i = 0; i < n; ++i)
        {
            // TODO: Change this to not use magic numbers
            GameObject newAgent = Instantiate(agentPrefab, new Vector3(Random.Range(-this.SpawnRadius, this.SpawnRadius), Random.Range(-this.SpawnRadius, this.SpawnRadius), 0), Quaternion.identity) as GameObject;

            // TODO: better way to do this?
            this.Agents.Add(newAgent.GetComponent<Agent>());
        }
    }

    /// <summary>
    /// Find a list of all nearby neighbors
    /// </summary>
    /// <param name="agent"></param>
    /// <param name="radius"></param>
    /// <returns>Return list of neighbors</returns>
    public List<Agent> GetNeighbors(Agent agent, float radius)
    {
        // Create list of nearby by neighbors
        List<Agent> neighbors = new List<Agent>();

        // Loop through agents
        for (int i = 0; i < this.Agents.Count; ++i)
        {
            // Check if if not this agent and that it is in the distance
            if (this.Agents[i] != agent && Vector2.Distance(agent.transform.position, this.Agents[i].transform.position) <= radius)
            {
                // Add neibhor to list
                neighbors.Add(this.Agents[i]);
            }
        }

        // Return result
        return neighbors;
    }

    /// <summary>
    /// Wrap around to keep agent in screen
    /// </summary>
    /// <param name="velocity"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    public Vector3 WrapAround(Vector3 pos)
    {
        pos.x = this.wrapAroundFloat(pos.x, -ScreenBounds.x, ScreenBounds.x);
        pos.y = this.wrapAroundFloat(pos.y, -ScreenBounds.y, ScreenBounds.y);

        return pos;
    }

    private float wrapAroundFloat(float val, float min, float max)
    {
        if (val > max)
        {
            val = min;
        }
        else if (val < min)
        {
            val = max;
        }

        return val;
    }

    public List<Predator> GetPredators(Vector3 pos, float radius)
    {
        // Create list of nearby by neighbors
        List<Predator> predators = new List<Predator>();

        // Loop through agents
        for (int i = 0; i < this.Predators.Count; ++i)
        {
            // Check if if not this agent and that it is in the distance
            if (Vector2.Distance(pos, this.Predators[i].transform.position) <= radius)
            {
                // Add neibhor to list
                predators.Add(this.Predators[i]);
            }
        }

        // Return result
        return predators;
    }
}
