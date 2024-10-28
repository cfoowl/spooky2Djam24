using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;
    public List<NPC> NPCs = new List<NPC>();
    public int maxSprite;
    public List<int> spriteIDAvailable;
    public GameObject NPCprefab;
    public string[] firstnameList;
    public string[] surnameList;
    public string[] deathCauseSentences;
    public string[] greetings;
    public Sprite[] hatSprites;
    public Sprite[] defaultSprites;
    public float centerRadius = 2f;
    public float spawnCDMin = 10f;
    public float spawnCDMax = 15f;
    private int IDnumber = 0;
    private float N_spawn = 0;

    void Awake() {
        instance = this;
        maxSprite = hatSprites.Length*defaultSprites.Length;
        spriteIDAvailable = Enumerable.Range(0,maxSprite).ToList();
    }
    void Start()
    {
        N_spawn = 0;
        Invoke("SpawnNPC", 3);
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer() {
        while (true) {
            float cooldown = generateCooldown();
            Debug.Log("Cooldown : " + cooldown);
            WaitForSeconds wait = new WaitForSeconds(cooldown);
            yield return wait;
            SpawnNPC();
        }

    }

    float generateCooldown() {
        if(N_spawn <= 0) {
            float max_big_spawn_time = 150 / Mathf.Sqrt(Time.time + 100) + 15;
            N_spawn = Mathf.Ceil(Time.time / 50);
            return Random.Range(max_big_spawn_time -10, max_big_spawn_time);
        } else {
            float max_small_spawn_time = 150 / Mathf.Sqrt(Time.time + 100);
            N_spawn--;
            return Random.Range(1, max_small_spawn_time);
        }

    }

    void SpawnNPC(){
        if (spriteIDAvailable.Count == 0) {
            return;
        }
        Vector3 spawnPosition = new Vector3(Random.Range(-centerRadius, centerRadius), Random.Range(-centerRadius, centerRadius), 0);
        Quaternion spawnRotation = Quaternion.identity;
        GameObject newInstance = Instantiate(NPCprefab, spawnPosition, spawnRotation);
        NPC script = newInstance.GetComponent<NPC>();
        NPCs.Add(script);


        script.centerRadius = centerRadius;

        script.IDname = firstnameList[Random.Range(0, firstnameList.Length)] + " " + surnameList[Random.Range(0, surnameList.Length)];
        script.ID = IDnumber++;
        
        GenerateNPCAppearance(script);

        int deathCauseIndex = Random.Range(1, 4);
        script.deathCause = (EDeathCauses) deathCauseIndex;
        script.sentence = greetings[Random.Range(0,greetings.Length)] + " , ";
        script.sentence += "I'm " + script.IDname + ". ";
        script.sentence += deathCauseSentences[(deathCauseIndex-1)*5 + Random.Range(0,5)] + "...";


        // Patience 
        float patienceMax = 800 / Mathf.Sqrt(Time.time + 100) + 10;
        float patienceMin = 400 / Mathf.Sqrt(Time.time + 100) + 10;

        script.patienceMax = Random.Range(patienceMin, patienceMax);

        SoundManager.instance.PlaySpawnGhostSound();

    }

    public List<string> getNameList() {
        List<string> names = new List<string>();
        foreach(NPC npc in NPCs) {
            names.Add(npc.IDname);
        }
        return names;
    }

    public void GenerateNPCAppearance(NPC script){
        int spriteID = spriteIDAvailable[Random.Range(0,spriteIDAvailable.Count)];
        spriteIDAvailable.Remove(spriteID);

        script.hatIndex = spriteID / defaultSprites.Length;
        int colorIndex = spriteID % defaultSprites.Length;

        script.nPCSprite.changeHatSprite(hatSprites[script.hatIndex], script.hatIndex);
        script.colorIndex = colorIndex;
        script.nPCSprite.changeBodySprite(defaultSprites[colorIndex]);

        script.spriteID = spriteID;
    }
}
