using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float _health;

    private float _jump_force;

    private float _gravity;
    private bool isStaminaDraining;

    [SerializeField] private float _stamina;
    
    public float Health;
    const float MAXHEALTH = 100f;
    const float MAXSTAMINA = 100f;

    private float _speed = 5f;


    void Awake()
    {


    }
    void Start()
    {
        _health = 100f;
        _jump_force = 10f;
        _gravity = 15f;
        _stamina = MAXSTAMINA;
    }

    // Update is called once per frame
    void Update()
    {
        RegenStamina();
    }

    public void SetHealth(float health)
    {
        _health += health;
        _health = Mathf.Clamp(_health, 0, MAXHEALTH);
    }

    public void RegenStamina()
    {
            if (_stamina < MAXSTAMINA){
            _stamina += 0.02f;
            }   
    }

    public void DrainStamina(float amount)
    {
        _stamina -= amount;
    }
    public float GetStamina()
    {
        return _stamina;
    }



    public float GetHealth() {
    return _health;

    }



    public float GetJumpForce()
    {
        return _jump_force;
    }

    public float GetGravity()
    {
        return _gravity;
    }


    public float GetSpeed()
    {
        return _speed;
    } 
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
