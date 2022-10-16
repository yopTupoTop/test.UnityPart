using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBlockController : MonoBehaviour
{
    [SerializeField] private float radius;
    private GameObject player;
    private GameObject message;

    private void Start()
    {
        message = gameObject.transform.Find("message").gameObject;
        player = GameObject.Find("player");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < radius)
        {
            message.SetActive(true);
        }
    }

    private void OnMouseDown()
    {

    }
}
