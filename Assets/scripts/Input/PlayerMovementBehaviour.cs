using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Transform Enemy;
    public float Move = 10;
    public float Turn = 50;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //changes x and going foreward
        if(Input.GetButtonDown("W"))
        {
            _rigidbody.AddRelativeForce(new Vector3(0, 0, Move), ForceMode.Impulse);
        }
        //rotates y
        else if (Input.GetButtonDown("A"))
        {
            transform.Rotate(new Vector3(0, -Turn, 0) * Time.deltaTime * 100, Space.World);
        }
        //changes x and going backwards 
        else if (Input.GetButtonDown("S"))
        {
            _rigidbody.position += transform.forward * Time.deltaTime * speed;
            _rigidbody.AddRelativeForce(new Vector3(0, 0, -Move), ForceMode.Impulse);
        }
        //rotates y
        else if (Input.GetButtonDown("D"))
        {
            transform.Rotate(new Vector3(0, Turn, 0) * Time.deltaTime * 100, Space.World);
        }

        //transform.LookAt(Input.mousePosition);

        if (Input.GetButtonDown("Escape"))
        {
            End();
        }
    }

    /// <summary>
    /// These do the same thing as the Input.GetButton If styatements does
    /// except its functions for buttons
    /// </summary>

    public void W()
    {
        //changes x and going foreward
        _rigidbody.AddRelativeForce(new Vector3(0, 0, Move), ForceMode.Impulse);
    }

    public void A()
    {
        //rotates to the left
        transform.Rotate(new Vector3(0, -Turn, 0) * Time.deltaTime * 100, Space.World);
    }

    public void S()
    {
        //moves player backwards depending on the direction facing
        _rigidbody.position += transform.forward * Time.deltaTime * speed;
        _rigidbody.AddRelativeForce(new Vector3(0, 0, -Move), ForceMode.Impulse);
    }

    public void D()
    {
        //rotates to the right
        transform.Rotate(new Vector3(0, Turn, 0) * Time.deltaTime * 100, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Killer"))
            End();
    }

    void End()
    {
        Application.Quit();
    }
}
