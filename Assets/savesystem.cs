using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class savesystem
{
    public static List<userdata> userlist;
    public static void saveplayer(getinfo usergetinfo)
    {
        string path = Application.persistentDataPath + "/phonerecords2.fun";
        if (File.Exists(path))
        {
            userlist = fileopen(path);
            if (userlist == null)
            {
                userlist = new List<userdata>();
            }
         
             //userlist.Add(userlist);
         
            path = fileappend(path, usergetinfo);

        }
        else
        {
            path = filecreate(path, usergetinfo);
        }
    }



    public static List<userdata> loadplayer()
    {
        string path = Application.persistentDataPath + "/phonerecords2.fun";
        if (File.Exists(path))
        {
            return fileopen(path);
        }
        else
        {
            Debug.LogError("save file not found in " + path);
            return null;
        }
    }

    private static List<userdata> fileopen(string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        if (stream.Length > 0)

        {
            var data = formatter.Deserialize(stream);
            List<userdata> data1 = (List<userdata>)data;
            stream.Close();

            if (data1 == null)
                return null;
            else
                return data1;
        }
        stream.Close();
        return null;
    }

    private static string filecreate(string path, getinfo usergetinfo)
    {

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);
        userdata newuserdata = new userdata(usergetinfo);
        Debug.Log("the liust is " +newuserdata.mobilenumber);
        userlist.Add(newuserdata);
       
        formatter.Serialize(stream, userlist);
        stream.Close();
        ///no need for below
        return path;
    }

    private static string fileappend(string path, getinfo usergetinfo)
    {

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);
        userdata newuserdata = new userdata(usergetinfo);
        Debug.Log("the liust is " + newuserdata.mobilenumber);
        userlist.Add(newuserdata);
        formatter.Serialize(stream, userlist);
        stream.Close();

        ///no need for below
        return path;
    }


}

//public class Playerdata
//{

//    public userdata myuserdata;
//}