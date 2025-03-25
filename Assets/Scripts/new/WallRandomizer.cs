using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRandomizer : MonoBehaviour
{
    public GameObject[] walls;
    public int enabledWalls;
    void Start()
    {
        for (int i = 0; i < enabledWalls; i++)
        {
            int random=Random.Range(0, walls.Length);
            if (walls[random].activeSelf==false)
            {
                walls[random].SetActive(true);
            }else
            {
                i--;
            }
        }
    }
}
