using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour 
{
    public Vector2 velocity;
    
    private World world;
    private Rigidbody2D rb;

    
    private Vector2 acceleration;

    void Start ()
    {
        // TODO: change to singleton
        this.world = FindObjectOfType<World>();

        // get rb
        this.rb = this.GetComponent<Rigidbody2D>();
	}
	
    /// <summary>
    /// Update movement of agent
    /// </summary>
	void FixedUpdate ()
    {
        // Update acceleration
        this.acceleration = Vector2.ClampMagnitude(this.Combine(), AgentConfig.Instance.MaxAcceleration);

        // Euler Forward Integration
        this.velocity = Vector2.ClampMagnitude(this.velocity + this.acceleration * Time.deltaTime, AgentConfig.Instance.MaxVelocity);

        // TODO: find way to not create a new vector every time
        this.transform.position = this.transform.position + new Vector3(this.velocity.x * Time.deltaTime, this.velocity.y * Time.deltaTime, 0);
	}

    public Vector2 Cohesion()
    {
        return Vector2.zero;
    }

    public Vector2 Separation()
    {
        return Vector2.zero;
    }

    public Vector2 Allignment()
    {
        return Vector2.zero;
    }

    public Vector2 Combine()
    {
        return Vector2.zero;
    }

  
}
