using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPoleScript : MonoBehaviour
{
    [SerializeField] private GameObject[] players = new GameObject[6];
    public GameObject NewPole;
    private float velocity = 10;
    public bool isMovingPink;
    public bool enabledMap;
    private map map;
    [SerializeField] GameObject Cubes;

    private void Start()
    {
        isMovingPink = false;
        enabledMap = true;
        map=Cubes.GetComponent<map>();
    }

    void Update()
    {
        if (enabledMap)
        {
            map.enabled = true;
        }
        else
        {
            map.enabled = false;    
        }
        Debug.Log(enabledMap);

        if (!isMovingPink && Vector3.Distance(players[GameData.currentPlayer].transform.position, this.transform.position) < 0.01f && map.PlayerPositions[GameData.currentPlayer] == Convert.ToInt32(this.gameObject.name))
        {

            enabledMap = false;
            isMovingPink = true;

        }

        if (isMovingPink)
        {
            players[GameData.currentPlayer].transform.position = Vector3.MoveTowards(
                players[GameData.currentPlayer].transform.position,
                NewPole.transform.position,
                Time.deltaTime * velocity
            );
            if (Vector3.Distance(players[GameData.currentPlayer].transform.position, NewPole.transform.position) < 0.01f)
            {
                isMovingPink = false;
                enabledMap = true;
                players[GameData.currentPlayer].GetComponent<Animator>().SetTrigger("MoveEnd");
                map.PlayerPositions[GameData.currentPlayer] = Convert.ToInt32(NewPole.gameObject.name);

                map.EndMove();
            }
        }
    }


}
