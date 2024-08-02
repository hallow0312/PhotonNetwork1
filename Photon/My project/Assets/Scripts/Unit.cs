using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    RUN,
    ATTACK,
    DIE
}
public class Unit : MonoBehaviour
{
    [SerializeField] State state;
    [SerializeField] float UnitSpeed = 2.0f;
    [SerializeField] GameObject tower;
    [SerializeField] Animator anim;
    [SerializeField] float health;
    private void Start()
    {
        health = 100.0f;
        state = State.RUN;
        tower = GameObject.Find("Tower");
        transform.LookAt(tower.transform.position);
    }

    public void Update()
    {
        switch(state)
        {
            case State.RUN: Run();
                break;
                case State.ATTACK: Attack();
                break;
                case State.DIE:
                Die();
                break;

        }
    }
    public void Run()
    {
        transform.position = Vector3.MoveTowards(transform.position, tower.transform.position, UnitSpeed * Time.deltaTime);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower"))
        {

            state = State.ATTACK;
        }

    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
    
    }

    public void Die()
    {
        PhotonNetwork.Destroy(gameObject);
    }
    public void Damage(float damage)
    {
        health -= damage;
        if(health<=0)
        {
            state = State.DIE;
        }
    }
}
