using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.models
{
public class film
{
private int _film_id;
private string _film_name;
public film()
{}
public film (int film_id,string film_name){ 
 this._film_id=film_id;
this._film_name=film_name;
 }
public int film_id { get=>_film_id; set => _film_id=value; } 
public string film_name { get=>_film_name; set => _film_name=value; } 

}
}
