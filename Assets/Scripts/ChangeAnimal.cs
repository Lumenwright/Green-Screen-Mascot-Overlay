using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeAnimal : MonoBehaviour
{
    [SerializeField] TMP_Dropdown _dropdown;
    [SerializeField] GameObject _sharkPartyHat;
//    [SerializeField] GameObject _tigerPartyHat;
    [SerializeField] GameObject _sharkUI;
//    [SerializeField] GameObject _tigerUI;
    [SerializeField] GameObject _shark;
//    [SerializeField] GameObject _tiger;

    enum Animal {Shark, Tiger, Both};
    Animal _animal;

    [Tooltip("Party hat?")]
    public bool PartyTime;

    // Start is called before the first frame update
    void Start()
    {
        List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
        foreach(string name in System.Enum.GetNames(typeof(Animal))){
            TMP_Dropdown.OptionData animal = new TMP_Dropdown.OptionData(name,null);
            list.Add(animal);
        }
        _dropdown.AddOptions(list);
        ActivateShark();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChanged(){
        switch(_dropdown.value){
            case ((int)Animal.Shark):
                ActivateShark();
                break;
            
            case ((int)Animal.Tiger):
                ActivateTiger();
                break;
            case ((int)Animal.Both):
                ActivateBoth();
                break;
        }
    }

    public void ActivatePartyTime(bool partyTime){
        PartyTime = partyTime;
        _sharkPartyHat.SetActive(partyTime);
//        _tigerPartyHat.SetActive(partyTime);
    }

    void ActivateShark(){
        _sharkUI.SetActive(true);
        _shark.SetActive(true);
//        _tiger.SetActive(false);
//        _tigerUI.SetActive(false);
        if(PartyTime) 
            _sharkPartyHat.SetActive(true);
        else{
            _sharkPartyHat.SetActive(false);
        }
    }

    void ActivateTiger(){
        _sharkUI.SetActive(false);
        _shark.SetActive(false);
/*        _tiger.SetActive(true);
        _tigerUI.SetActive(true);
        if(PartyTime) 
            _tigerPartyHat.SetActive(true);
        else{
            _tigerPartyHat.SetActive(false);
        }*/
    }

    void ActivateBoth(){
       // _sharkUI.SetActive(true);
        _shark.SetActive(true);
    /*    _tiger.SetActive(true);
      //  _tigerUI.SetActive(true);
        _tigerPartyHat.SetActive(PartyTime);
        _sharkPartyHat.SetActive(PartyTime);*/
    }
}
