using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ChaseBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Transform Player;
    float MoveSpeed = 4;
    float MaxDist = 10;
    float MinDist = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            _rigidbody.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
    }
}
