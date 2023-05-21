using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public float spawnRate = 1f;
    public float minAltura = -2f;
    public float maxAltura = 2f;

    [System.Serializable]
    public struct spawnObj
    {
        public GameObject prefab;
        [Range(0f,1f)]
        public float spawnChance;
    }
    public spawnObj[] objetos;

    public void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        float spawnChance = Random.value;
        foreach (var obj in objetos){
            if (spawnChance < obj.spawnChance){
                GameObject planetas = Instantiate(obj.prefab, transform.position, Quaternion.identity);
                planetas.transform.position += Vector3.up * Random.Range(minAltura, maxAltura);
                break;
            }
            spawnChance -= obj.spawnChance; // n spawnam uns em cima dos outros
        }
        
    }
}
