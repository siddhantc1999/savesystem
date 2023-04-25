using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getinfo : MonoBehaviour
{
    [SerializeField] GameObject useridinputfield;
    public string userid;
    [SerializeField] GameObject passwordinputfield;
    public string password;
    [SerializeField] GameObject nameinputfield;
    public string name;
    [SerializeField] GameObject mobileinputfield;
    public string mobilenumber;
    List<userdata> myuserdata;
    public void assignuserid()
    {
        userid = useridinputfield.GetComponent<InputField>().text;
    }
    public void assignpassword()
    {
        password = passwordinputfield.GetComponent<InputField>().text;
    }
    public void assignname()
    {
        name = nameinputfield.GetComponent<InputField>().text;
    }
    public void assignmobilenum()
    {
        mobilenumber = mobileinputfield.GetComponent<InputField>().text;
    }
    public void registerplayer()
    {

        savesystem.saveplayer(this);


    }
    public void loadplayer()
    {
        myuserdata=savesystem.loadplayer();

    }



}
