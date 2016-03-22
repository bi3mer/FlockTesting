using UnityEngine;
using System.Collections;

public class AgentConfig : MonoBehaviour 
{
    // TODO: add line breaks in inspector and create better names
    public float Rc;
    public float Rs;
    public float Ra;

    public float Kc;
    public float Ks;
    public float Ka;

    public float MaxAcceleration;
    public float MaxVelocity;


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
