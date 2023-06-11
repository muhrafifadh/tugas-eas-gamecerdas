using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
   public Text healthText;
    private CharacterStats characterStats;

    // Start is called before the first frame update
    void Start()
    {
        // Mencari objek dengan skrip CharacterStats
        GameObject character = GameObject.FindGameObjectWithTag("Player");

        // Memeriksa apakah objek dengan skrip CharacterStats ditemukan
        if (character != null)
        {
            // Mencari komponen CharacterStats pada objek tersebut
            characterStats = character.GetComponent<CharacterStats>();
        }

        // Memastikan teks UI terhubung dengan objek UI Text
        healthText = GetComponent<Text>();

        // Mengupdate teks UI
        UpdateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        // Memeriksa jika ada perubahan pada nilai kesehatan
        if (characterStats != null && characterStats.currentHealth != int.Parse(healthText.text))
        {
            UpdateHealthText();
        }
    }

    // Mengupdate teks UI dengan nilai kesehatan yang sesuai
    public void UpdateHealthText()
    {
        if (characterStats != null)
        {
            healthText.text = characterStats.currentHealth.ToString();
        }
    }
}
