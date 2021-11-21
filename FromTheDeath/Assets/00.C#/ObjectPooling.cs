using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    [SerializeField] GameObject snakePrefab;
    [SerializeField] GameObject batPrefab;


    public GameObject GetSnake(int maxCount, List<GameObject> snakeList)
    {
        if (snakeList.Count <maxCount)
        {
            GameObject s = Instantiate(snakePrefab, this.transform.position, Quaternion.identity);
            s.SetActive(false);
            snakeList.Add(s);
            return s;
        }

        else if (snakeList.Count >=maxCount)
        {
            foreach (GameObject s in snakeList)
            {
                if (s.activeSelf)
                {
                    continue;
                }
                else if (!s.activeSelf)
                {
                    return s;
                }
                break;
            }
        }
        
        return null;

    }

    public GameObject GetBat(int maxCount, List<GameObject> batList)
    {
        if (batList.Count < maxCount)
        {
            GameObject s = Instantiate(batPrefab, this.transform.position, Quaternion.identity);
            s.SetActive(false);
            batList.Add(s);
            return s;
        }

        else if (batList.Count >= maxCount)
        {
            foreach (GameObject s in batList)
            {
                if (s.activeSelf)
                {
                    continue;
                }
                else if (!s.activeSelf)
                {
                    return s;
                }
                break;
            }
        }

        return null;

    }

}
