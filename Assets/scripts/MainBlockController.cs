using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBlockController : MonoBehaviour
{
    [SerializeField] private float radius;

    [SerializeField] private GameObject message;
    private GameObject player;
    private GameObject votingConstruction;
    private VotingConstructionController[] vCArrey;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vCArrey = GameObject.FindObjectsOfType<VotingConstructionController>(true);
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            message.SetActive(true);
        }

        if (Vector3.Distance(transform.position, player.transform.position) > radius)
        {
            message.SetActive(false);
        }
        foreach (var i in vCArrey)
        {
            if (Vector3.Distance(this.gameObject.transform.position, i.gameObject.transform.position) > radius)
            {
                i.gameObject.SetActive(false);
                this.gameObject.SetActive(true);
            }
        }
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            this.gameObject.SetActive(false);
            foreach (var i in vCArrey)
            {
                if (Vector3.Distance(this.gameObject.transform.position, i.gameObject.transform.position) < radius)
                {
                    i.gameObject.SetActive(true);
                }
            }
        }
    }
}
