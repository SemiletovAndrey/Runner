using Firebase.Auth;
using Firebase;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseGameManager : MonoBehaviour
{
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;

    private void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void Logout()
    {
        auth.SignOut();
        Debug.Log("User logged out.");
    }
}
