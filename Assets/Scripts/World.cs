using UnityEngine;
using System.Collections.Generic;

public class World : MonoBehaviour
{
    public GameObject AgentPrefab;
    public int NumberOfAgents;

    public Vector2 ScreenBounds;
    public float SpawnRadius;
	

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
        this.Spawn(AgentPrefab, this.NumberOfAgents);
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
       		Instantiate(agentPrefab, new Vector3(Random.Range(-this.SpawnRadius, this.SpawnRadius), Random.Range(-this.SpawnRadius, this.SpawnRadius), 0), Quaternion.identity);
        }
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
}
