using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    [Header("Grille")]
    public GeneratorData  generatorData;
    public ElementData[] elements;
    
    public List<TablerStudio> tablerStudios;
    public string voidId = "V";
    
    public string code;
    
    public GameObject parentLevelElement;
    public DefaultElement placeHolder;
    

    [Header("Editor")] 
    public bool isEditor;
    public GameObject parentButton;
    public ElementData[] editorElements;
    
    
    
    void Start()
    {
        NewTabler(code);
        
        if(isEditor) OpenEditor();
        else parentButton.SetActive(false);
    }
    

    void NewTabler(string code)
    {
        Vector2 _startPos = generatorData.startPos;
        tablerStudios =  new List<TablerStudio>();
        foreach (DefaultElement element in parentLevelElement.GetComponentsInChildren<DefaultElement>())
        {
            Destroy(element.gameObject);
        }
        
        int index = 0;
        Debug.Log(code);
        for (int i = 0; i < generatorData.nbrColone; i++)
        {
            tablerStudios.Add(new TablerStudio());
            for (int j = 0; j < generatorData.nbrLigne; j++)
            {
                DefaultElement element = Instantiate(placeHolder,new Vector3(_startPos.x, _startPos.y, 0), Quaternion.identity, parentLevelElement.transform);
                tablerStudios[^1].lignes.Add(element);
                
                if (index < code.Length) element.Refresh(LettreToElement(code[index].ToString()));
                else element.Refresh(LettreToElement(voidId));
                
                element.position = new Vector2(i, j);
                
                _startPos.x +=  generatorData.marge;
                index++;
            }
            _startPos.x = generatorData.startPos.x;
            _startPos.y += generatorData.marge;
        }
    }

    void OpenEditor()
    {
        parentButton.SetActive(true);

        int index = 0;
        foreach (var selectElement in parentButton.GetComponentsInChildren<SelectElement>())
        {
            if (editorElements.Length > index)
            {
                selectElement.Set(editorElements[index]);
                index++;
            }
            else selectElement.gameObject.SetActive(false);
        }
        
    }
    
    public void CreateNewLevel()
    {
        string newCode = "";
        for (int i = 0; i < tablerStudios.Count; i++)
        {
            for (int j = 0; j < tablerStudios[i].lignes.Count; j++)
            {
                newCode += tablerStudios[i].lignes[j].currentElement.id;
            }
        }
        GUIUtility.systemCopyBuffer =  newCode;
        Debug.Log(newCode + "past");
    }
    
    protected ElementData LettreToElement(string letter)
    {
        foreach (ElementData data in elements)
        {
            if (data.id == letter)
            {
                return data;
            }
        }
        return LettreToElement("V");
    }
    
    /**protected virtual string Decoder(string code)
   {
       var match = Regex.Match(code, @"^\[(?<player>[^\]]+)\]\{(?<map>[^\}]+)\}\((?<pattern>\d+)\)(?<seed>.+)$");
       return match.Groups["seed"].Value;
   }
   **/
    
}
[System.Serializable]
public class TablerStudio
{
    public List<DefaultElement> lignes =  new List<DefaultElement>();
}