using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Firebase.Database;
using Firebase.Analytics;
using Firebase.Auth;
using UnityEngine.Assertions;
using Firebase.Storage;






public class UserData : MonoBehaviour
{
    public Firebase.FirebaseApp reference; //{ get; set; }
    


    // Start is called before the first frame update
    void Start()
    {

        //Firebase.FirebaseApp.GetInstance("");

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            Firebase.FirebaseApp app = Firebase.FirebaseApp.GetInstance("https://unity-game-767f2-default-rtdb.firebaseio.com/");
            //DataSnapshot snapshot = task.
            string json = JsonUtility.ToJson(app);

            Debug.Log(json);

            

        });


        
        //reference = Firebase.FirebaseApp.GetInstance("");

        //reference.CheckAndFixDependenciesAsync().ContinueWith


    }

    // Update is called once per frame
    void Update()
    {

    }
}
