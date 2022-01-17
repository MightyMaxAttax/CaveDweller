using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float attack;

    [SerializeField]
    private float distance;

    [SerializeField]
    private float bounceBack;

    protected GameObject player;

    protected int damage = 1;

    public ContactFilter2D filter;

    protected Collider2D[] hits = new Collider2D[10];

    private Collider2D enemyCollider;

    protected virtual void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        
        enemyCollider = GetComponent<Collider2D>();
    }

    protected virtual void Update()
    {
        enemyCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            OnCollide(hits[i]);

            //The array is no cleaned up, so we do it ourselves
            hits[i] = null;
        }
    }


    protected virtual void OnCollide(Collider2D col)
    {
        Debug.Log(col.name);
    }

}
