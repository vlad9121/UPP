using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizedText : MonoBehaviour
{
    [SerializeField]
    protected string key;

    protected LocalizationManager localizationManager;
    protected Text text;
    
    void Awake()
    {
        if (localizationManager == null)
        {
            localizationManager = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();
        }
    if (text == null)
        {
            text = GetComponent<Text>();
        }
        localizationManager.OnLanguageChanged += UpdateText;
    }

    void Start()
    {
        UpdateText();
    }



    private void OnDestroy()
    {
        localizationManager.OnLanguageChanged -= UpdateText;
    }

    virtual protected void UpdateText()
    {
        if (gameObject == null) return;

        if (localizationManager == null)
        {
            localizationManager = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();
        }
        if (text == null)
        {
            text = GetComponent<Text>();
        }
        text.text = localizationManager.GetLocalizedValue(key);
    }




}
