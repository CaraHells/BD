using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.models
{
public class seance_type
{
private int _seanse_type_id;
private string _seanse_type_name;
public seance_type()
{}
public seance_type (int seanse_type_id,string seanse_type_name){ 
 this._seanse_type_id=seanse_type_id;
this._seanse_type_name=seanse_type_name;
 }
public int seanse_type_id { get=>_seanse_type_id; set => _seanse_type_id=value; } 
public string seanse_type_name { get=>_seanse_type_name; set => _seanse_type_name=value; } 

}
}
