using System.Collections.Generic;
using UnityEngine;

public class ArrayPlaceholder : MonoBehaviour
{
    [SerializeField]
    private GameObject[] array1, array2;

    void Start() => PlacingItemsInTheArray(array2, array1);

    private void PlacingItemsInTheArray(GameObject[] arrayFrom, GameObject[] arrayTo)
    {
        List<int> nullIndexesArrayTo = GetNullIndexes(arrayTo);

        Shuffle(nullIndexesArrayTo);
        Shuffle(arrayFrom);

        int n = 0, arrayFromLength = arrayFrom.Length;
        foreach (var item in nullIndexesArrayTo)
            if (n < arrayFromLength)
                arrayTo[item] = arrayFrom[n++];
    }

    private List<int> GetNullIndexes (GameObject[] array)
    {
        List<int> nullIndexesList = new List<int>();

        for (int i = 0; i < array.Length; i++)
            if (array[i] == null)
                nullIndexesList.Add(i);

        return nullIndexesList;
    }

    //the Fisher Yates Shuffle
    private void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            T tmp = list[i];
            list[i] = list[r];
            list[r] = tmp;
        }
    }
    private void Shuffle<T>(T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }
}
