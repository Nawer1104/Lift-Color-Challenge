using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Room : MonoBehaviour
{
    public Type type;

    public List<Person> people;

    public GameObject vfxCompleted;

    public Transform[] positions;

    private void Start()
    {
        SetPos();
    }

    private void SetPos()
    {
        foreach(Person person in people)
        {
            if (person != null)
            person.transform.position = positions[people.IndexOf(person)].position;
        }
    }

    public void CheckType()
    {
        if (people.Count != 3) return;

        if (people[0].type == this.type && people[1].type == this.type && people[2].type == this.type)
        {
            GameObject vfx = Instantiate(vfxCompleted, transform.position, Quaternion.identity);
            Destroy(vfx, 1f);

            foreach(Person person in people)
            {
                person.transform.DOScale(0, 1f).OnComplete(() => {
                    person.gameObject.SetActive(false);
                });
            }

            transform.DOScale(0, 1f).OnComplete(() => {
                GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
                GameManager.Instance.CheckLevelUp();
            });
        }
    }

    public void AddPerson(Person person)
    {
        if (people.Count < 3)
        {
            people.Add(person);

            person.transform.SetParent(transform);

            SetPos();

            CheckType();
        }
        else
            return;
    }

    public Person OutPerson()
    {
        if (people.Count == 0) return null;

        Person person = null;

        for (int i = 0; i < people.Count; i++) 
        {
            if (people[i].type != this.type && people[i] != null)
            {
                person = people[i];

                people.Remove(people[i]);

                return person;
            }
        }

        return person;
    }
}
