using UnityEngine;
using System.Collections;

public class AgentConfig : MonoBehaviour 
{
    // TODO: add line breaks in inspector and create better names
    public float CohesionRadius;
    public float SeparationRadius;
    public float AllignmentRadius;
    public float WanderRadius;
    public float AvoidRadius;

    public float CohesionWeight;
    public float SeparationWeight;
    public float AllignmentWeight;
    public float WanderWeight;
    public float AvoidWeight;

    public float MaxAcceleration;
    public float MaxVelocity;

    public float MaxFieldOfViewAngle = 180;
    public float Jitter;
    public float WanderDistance;



    // Singleton
    private static AgentConfig instance = null;
    public static AgentConfig Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<AgentConfig>();
            }
            return instance;
        }
    }
}
