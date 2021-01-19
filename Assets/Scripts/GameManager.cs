using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform fireBallSpawn;
    public GameObject fireBallPrefab;
    [SerializeField] private Material frostMaterial;
    private bool hasMelted = false;
    private bool startMelting = false;

    private void Start()
    {
        frostMaterial.SetFloat("_DissolveAmount", -1);
        Invoke("SpawnSpell", 1f);
        Invoke("FrostMelt", 5f);
        Invoke("ReloadScene", 12.5f);
    }

    void Update()
    {
        if (startMelting)
        {
            if (frostMaterial.GetFloat("_DissolveAmount") < 0.6f)
            {
                frostMaterial.SetFloat("_DissolveAmount", frostMaterial.GetFloat("_DissolveAmount") + Time.deltaTime * 0.25f);
            }
            else
            {
                hasMelted = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            ReloadScene();
        }
    }

    private void SpawnSpell()
    {
        Instantiate(fireBallPrefab, fireBallSpawn.position, Quaternion.identity);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void FrostMelt()
    {
        startMelting = true;
    }
}
