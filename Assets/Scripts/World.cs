using UnityEngine;
using System.Collections.Generic;

public class World : MonoBehaviour
{
    public GameObject AgentPrefab;
    public int NumberOfAgents;

    [HideInInspector]
    public List<Agent> Agents;

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
            GameObject newAgent = Instantiate(agentPrefab, new Vector3(Random.Range(-9, 9), Random.Range(-4, 4), 0), Quaternion.identity) as GameObject;

            // TODO: better way to do this?
            this.Agents.Add(newAgent.GetComponent<Agent>());
        }
    }

    public List<Agent> GetNeighbors(Agent agent, float radius)
    {
        // TODO: Update
        return null;
    }
}
