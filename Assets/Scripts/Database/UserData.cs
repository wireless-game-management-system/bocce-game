using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Firebase.Database;
using Firebase.Analytics;
<<<<<<< Updated upstream

public class UserData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //FirebaseDatabase.
=======
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


>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======

>>>>>>> Stashed changes
    }
}
