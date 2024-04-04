using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform pos;

    public Person person;

    private void Start()
    {
        SetPersonPos();
    }

    public void SetPersonPos()
    {
        if (person != null)
        {
            person.transform.SetParent(transform);
            person.transform.position = pos.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (person != null)
            {
                if (collision.GetComponent<Room>().people.Count < 3)
                {
                    collision.GetComponent<Room>().AddPerson(person);
                    person = null;
                }
            }
            else
            {
                person = collision.GetComponent<Room>().OutPerson();
                SetPersonPos();
            }
        } 
    }
}
