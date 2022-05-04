using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform SpawnPointLocation;
    public float DistanceToPlayer;
    public bool IsFacingLeft;

    private Animator _myAnim;

    // Start is called before the first frame update
    void Start()
    {
        _myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (CanSeePlayer(DistanceToPlayer))
        {
            ShootAtPlayer();
        }
        else
        {
            DontShootAtPlayer();
        }
    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if(IsFacingLeft)
        {
           castDist = -distance;
        }

        Vector2 endPos = transform.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(transform.position, endPos, 1 << LayerMask.NameToLayer("Player"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                ShootAtPlayer();
                val = true;
            }
            else
            {
                DontShootAtPlayer();
                val = false;
            }

            Debug.DrawLine(transform.position, endPos, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, endPos, Color.blue);
        }

        return val;
    }

    void ShootAtPlayer()
    {

        _myAnim.SetBool("Attack", true);
    }

    void DontShootAtPlayer()
    {

        _myAnim.SetBool("Attack", false);
    }

    void FireShot()
    {
        Instantiate(ProjectilePrefab, SpawnPointLocation.position, transform.rotation);
    }
}

