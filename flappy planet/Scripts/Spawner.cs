using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public float spawnRate = 1f;
    public float minHeight = -3f;
    public float maxHeight = 3f;

   

    [System.Serializable]
    public struct spawnObj
    {
        public GameObject prefab;
        [Range(0f,1f)]
        public float spawnChance;
    }
    public spawnObj[] objects;

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
        float spawnChance = Random.value;
        foreach (var obj in objects){
            if (spawnChance < obj.spawnChance){
                GameObject pipes = Instantiate(obj.prefab, transform.position, Quaternion.identity);
                pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
                break;
            }
            spawnChance -= obj.spawnChance; // n spawnam uns em cima dos outros
        }
        
    }

}
