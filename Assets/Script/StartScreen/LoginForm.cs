using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LoginForm {
    public string Email { get; set; }
    public string Password { get; set; }

    public LoginForm(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
