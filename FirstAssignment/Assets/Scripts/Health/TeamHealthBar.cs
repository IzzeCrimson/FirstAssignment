using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamHealthBar : MonoBehaviour
{

    private float maxTeamHealth;
    private float currentTeamHealth;
    private List<GameObject> team;
    Health healthScript;

    [SerializeField] bool isBlueHealthBar;
    [SerializeField] CharacterManager characterManager;
    [SerializeField] Slider healthBar;


    void Start()
    {

        if (isBlueHealthBar)
        {
            team = characterManager.blueTeamList;
        }
        else
        {
            team = characterManager.redTeamList;
        }

        for (int i = 0; i < team.Count; i++)
        {
            healthScript = team[i].gameObject.GetComponent<Health>();
            maxTeamHealth += healthScript.maxHealth;
        }

        healthBar.maxValue = maxTeamHealth;
        healthBar.value = maxTeamHealth;
    }

    private void UpdateHealthBar()
    {
        currentTeamHealth = 0;

        for (int i = 0; i < team.Count; i++)
        {
            if (team[i] != null)
            {
                healthScript = team[i].gameObject.GetComponent<Health>();
                currentTeamHealth += healthScript.currentHealth;

            }
        }
        healthBar.value = currentTeamHealth;

    }

    void Update()
    {

        UpdateHealthBar();


    }
}
