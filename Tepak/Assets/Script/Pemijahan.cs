using UnityEngine;

public class Pemijahan : MonoBehaviour
{
    //inisialisasi
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 2f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate); 
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        //agar kayu berubah-ubah posisi
        GameObject kayu = Instantiate(prefab, transform.position, Quaternion.identity);
        kayu.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
