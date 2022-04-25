
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;
public static class SaveSystem{
    public static void SavePlayer(GameManager manager, Player player){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(manager, player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    
    public static void SaveAsteroids(Asteroid [] asteroids){
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/asteroids.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        AsteroidData [] asteroidsDataList = new AsteroidData [asteroids.Length];

        for (int i = 0; i < asteroids.Length; i++) {
            AsteroidData data = new AsteroidData(asteroids[i]);
            asteroidsDataList[i] = data;
        }
        Asteroids asteroidsList = new Asteroids(asteroidsDataList);
        formatter.Serialize(stream, asteroidsList);
        stream.Close();
    }




    public static PlayerData LoadPlayer(){
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path)){
            //open the binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //open the file stream on already existing save file
            FileStream stream = new FileStream(path, FileMode.Open);

            //read from the stream, change it to readable format and save it 
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            //Return the data in the readable format
            return data;
        }else{
           //Log error
           Debug.LogError("Save file not found in"+path); 
           return null;
        }
    }

    public static Asteroids LoadAsteroids(){
        string path = Application.persistentDataPath + "/asteroids.fun";
        if(File.Exists(path)){
            //open the binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //open the file stream on already existing save file
            FileStream stream = new FileStream(path, FileMode.Open);

            //read from the stream, change it to readable format and save it 
            Asteroids data = formatter.Deserialize(stream) as Asteroids;
            stream.Close();
            //Return the data in the readable format
            return data;
        }else{
           //Log error
           Debug.LogError("Save file not found in"+path); 
           return null;
        }

    }
}