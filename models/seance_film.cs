using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.models
{
public class seance_film
{
private int _seance_film_id;
private int _seanse;
private int _film;
private DateTime _date;
public seance_film()
{}
public seance_film (int seance_film_id,int seanse,int film,DateTime date){ 
 this._seance_film_id=seance_film_id;
this._seanse=seanse;
this._film=film;
this._date=date;
 }
public int seance_film_id { get=>_seance_film_id; set => _seance_film_id=value; } 
public int seanse { get=>_seanse; set => _seanse=value; } 
public int film { get=>_film; set => _film=value; } 
public DateTime date { get=>_date; set => _date=value; } 

}
}
