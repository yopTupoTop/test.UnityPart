using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBlockController : MonoBehaviour
{
    [SerializeField] private float radius;

    [SerializeField] private GameObject message;
    private GameObject player;
    [SerializeField] private GameObject votingConstruction;
    [SerializeField] private GameObject mainBlock;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(votingConstruction);
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
    }

    private void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            mainBlock.SetActive(false);
            votingConstruction.SetActive(true);
        }
    }
}
