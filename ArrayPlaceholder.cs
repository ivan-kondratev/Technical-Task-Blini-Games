using System.Collections.Generic;
using UnityEngine;

public class ArrayPlaceholder : MonoBehaviour
{
    [SerializeField]
    private GameObject[] array1, array2;

    void Start() => PlacingItemsInTheArray(array2, array1);

    private void PlacingItemsInTheArray(GameObject[] arrayFrom, GameObject[] arrayTo)
    {
        List<int> nullElementIndexesOfArrayTo = new List<int>();

        for (int i = 0; i < arrayTo.Length; i++)
            if (arrayTo[i] == null)
                nullElementIndexesOfArrayTo.Add(i);

        Shuffle(nullElementIndexesOfArrayTo);
        Shuffle(arrayFrom);

        int n = 0, arrayFromLength = arrayFrom.Length;
        foreach (var item in nullElementIndexesOfArrayTo)
            if (n < arrayFromLength)
                arrayTo[item] = arrayFrom[n++];
    }

    //the Fisher Yates Shuffle
    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        System.Random random = new System.Random();
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T tempItem = list[k];
            list[k] = list[n];
            list[n] = tempItem;
        }
    }
    private void Shuffle(GameObject[] gameObjects)
    {
        int n = gameObjects.Length;
        System.Random random = new System.Random();
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            GameObject tempElement = gameObjects[k];
            gameObjects[k] = gameObjects[n];
            gameObjects[n] = tempElement;
        }
    }
}
