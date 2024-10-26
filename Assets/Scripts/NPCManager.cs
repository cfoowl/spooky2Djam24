using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;
    List<NPC> NPCs = new List<NPC>();
    public GameObject NPCprefab;
    public string[] firstnameList;
    public string[] surnameList;
    public float centerRadius = 2f;
    public float spawnCDMin = 10f;
    public float spawnCDMax = 15f;
    private int IDnumber = 0;

    void Awake() {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer() {
        while (true) {
            WaitForSeconds wait = new WaitForSeconds(Random.Range(spawnCDMin,spawnCDMax));
            yield return wait;
            SpawnNPC();
        }

    }

    void SpawnNPC(){
        Vector3 spawnPosition = new Vector3(Random.Range(-centerRadius, centerRadius), Random.Range(-centerRadius, centerRadius), 0);
        Quaternion spawnRotation = Quaternion.identity;
        GameObject newInstance = Instantiate(NPCprefab, spawnPosition, spawnRotation);
        NPC script = newInstance.GetComponent<NPC>();
        NPCs.Add(script);


        script.IDname = firstnameList[Random.Range(0, firstnameList.Length)] + " " + surnameList[Random.Range(0, surnameList.Length)];
        script.ID = IDnumber++;
        script.hasGlasses = Random.Range(0,2) == 0;
        script.hasHat = Random.Range(0,2) == 0;
        script.hasTie = Random.Range(0,2) == 0;
        script.hasCollar = Random.Range(0,2) == 0;
        script.centerRadius = centerRadius;

    }

    public List<string> getNameList() {
        List<string> names = new List<string>();
        foreach(NPC npc in NPCs) {
            names.Add(npc.IDname);
        }
        return names;
    }
}
