using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon_controller : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 2.0f;
    public float flightHeight = 10.0f;
    public float changeDirectionInterval = 3.0f;

    private Rigidbody rb_dragon;
    private Vector3 targetDirection;

    void Start()
    {
        rb_dragon = GetComponent<Rigidbody>();
        transform.position = new Vector3(transform.position.x, flightHeight, transform.position.z);
        StartCoroutine(ChangeDirectionRoutine());
    }

    void Update()
    {
        FlyAround();
    }

    IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectionInterval);
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        // Choose a random direction to fly towards
        float randomYaw = Random.Range(0f, 360f);
        float randomPitch = Random.Range(-45f, 45f);
        targetDirection = Quaternion.Euler(randomPitch, randomYaw, 0) * Vector3.forward;
    }

    void FlyAround()
    {
        // Move forward
        rb_dragon.velocity = transform.forward * speed;

        // Gradually turn towards the target direction
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        // Maintain flight height
        Vector3 position = transform.position;
        position.y = flightHeight;
        transform.position = position;
    }
}
