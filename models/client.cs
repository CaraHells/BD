using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.models
{
public class client
{
private int _client_id;
private string _firstname;
private string _lastname;
private string _email;
private string _password;
public client()
{}
public client (int client_id,string firstname,string lastname,string email,string password){ 
 this._client_id=client_id;
this._firstname=firstname;
this._lastname=lastname;
this._email=email;
this._password=password;
 }
public int client_id { get=>_client_id; set => _client_id=value; } 
public string firstname { get=>_firstname; set => _firstname=value; } 
public string lastname { get=>_lastname; set => _lastname=value; } 
public string email { get=>_email; set => _email=value; } 
public string password { get=>_password; set => _password=value; } 

}
}
