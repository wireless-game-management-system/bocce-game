using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{
    public bool IsFirebaseReady { get; private set; }
    public bool IsSignInOnProgress { get; private set; }

    public InputField emailField;
    public InputField passwordField;
    public Button signInButton;
    public Button registerButton;

    public static FirebaseApp firebaseApp;
    public static FirebaseAuth firebaseAuth;

    public static FirebaseUser User;

    public void Start()
    {
        signInButton.interactable = false;
        
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(continuationAction: task =>
        { 
            var result = task.Result;

            if (result != DependencyStatus.Available)
            {
                Debug.LogError(result.ToString());
                IsFirebaseReady = false;
            }
            else
            {
                IsFirebaseReady = true;

                firebaseApp = FirebaseApp.DefaultInstance;
                firebaseAuth = FirebaseAuth.DefaultInstance;
            }

            signInButton.interactable = IsFirebaseReady;

        }
       );
    }

    public void SignIn()
    {
        if (!IsFirebaseReady || IsSignInOnProgress || User != null)
        {
            return;
        }

        IsSignInOnProgress = true;
        signInButton.interactable = false;

        firebaseAuth.SignInWithEmailAndPasswordAsync(emailField.text, passwordField.text).ContinueWithOnMainThread(
            continuation: (task) =>
        {

            Debug.Log(message: $"Sign in status : {task.Status}");

            IsSignInOnProgress = false;
            signInButton.interactable = true;

            if (task.IsFaulted)
            {
                Debug.LogError(task.Exception);
            }

            else if (task.IsCanceled)
            {
                Debug.LogError("Sign in canceled");
            }

            else
            {
                User = task.Result;
                Debug.Log(User.Email);
                SceneManager.LoadScene("screen1");
            }

        });
    }

    public void Register()
    {
        firebaseAuth.CreateUserWithEmailAndPasswordAsync(emailField.text, passwordField.text).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.Log("Successfully Registered! Sign in Now");
        });
    }

}