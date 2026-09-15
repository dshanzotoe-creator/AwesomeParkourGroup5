using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float _health;
    private float _speed;
    private float _jump_force;
    private float _sprint_speed;

    private float _stamina;
    private float _gravity;
    public float Health;
    public float Speed;
    const float MAXHEALTH = 100;


    void Awake()
    {


    }
    void Start()
    {
        _health = 100f;
        _speed = 0f;
        _sprint_speed = 0f;
        _jump_force = 10f;
        _gravity = -20f;
        _stamina = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(float health)
    {
        _health += health;
        _health = Mathf.Clamp(_health, 0, MAXHEALTH);
    }

    public float GetHealth() {
    return _health;

    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public float GetSpeed() {
        return _speed;
    }


    public float GetJumpForce()
    {
        return _jump_force;
    }

    public float GetGravity()
    {
        return _gravity;
    }

    public float GetStamina()
    {
        return _stamina;
    }
}
