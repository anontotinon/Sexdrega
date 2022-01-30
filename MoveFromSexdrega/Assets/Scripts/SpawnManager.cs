using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager instance;

    public GameObject woodPrefab;

    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("> 1 instance of SpawnManager found. ");
            return;
        }
        instance = this;
    }
    #endregion

    public void SpawnWood(Transform trans, int nr)
    {
        System.Random rand = new System.Random();
        for(int i = 0; i<nr; i++)
        {
            Vector3 newPos = trans.position;
            newPos.y = newPos.y + 5 + rand.Next(-2,2);
            newPos.x = newPos.x + rand.Next(-2, 2);
            newPos.y = newPos.y + rand.Next(-2,2);

            Instantiate(woodPrefab, newPos, trans.rotation);
        }
        //Vector3 newPos = trans.position;
        //newPos.y = newPos.y + 5;
        //Instantiate(woodPrefab, newPos, trans.rotation);
    }
}
