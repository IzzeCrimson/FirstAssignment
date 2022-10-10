using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamHealthBar : MonoBehaviour
{

    private float _maxTeamHealth;
    private float _currentTeamHealth;
    private List<GameObject> _characters;
    Health healthScript;

    [SerializeField] private bool _isBlueHealthBar;
    [SerializeField] private CharacterManager _characterManager;
    [SerializeField] private Slider _healthBar;


    void Start()
    {

        if (_isBlueHealthBar)
        {
            _characters = _characterManager.blueTeamList;
        }
        else
        {
            _characters = _characterManager.redTeamList;
        }

        for (int i = 0; i < _characters.Count; i++)
        {
            healthScript = _characters[i].gameObject.GetComponent<Health>();
            _maxTeamHealth += healthScript.maxHealth;
        }

        _healthBar.maxValue = _maxTeamHealth;
        _healthBar.value = _maxTeamHealth;
    }

    private void UpdateHealthBar()
    {
        _currentTeamHealth = 0;

        for (int i = 0; i < _characters.Count; i++)
        {
            if (_characters[i] != null)
            {
                healthScript = _characters[i].gameObject.GetComponent<Health>();
                _currentTeamHealth += healthScript.currentHealth;

            }
        }
        _healthBar.value = _currentTeamHealth;

    }

    void Update()
    {

        UpdateHealthBar();


    }
}
