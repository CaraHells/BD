using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.models
{
public class order
{
private int _order_id;
private int _client;
private int _seance_film;
private int _place;
public order()
{}
public order (int order_id,int client,int seance_film,int place){ 
 this._order_id=order_id;
this._client=client;
this._seance_film=seance_film;
this._place=place;
 }
public int order_id { get=>_order_id; set => _order_id=value; } 
public int client { get=>_client; set => _client=value; } 
public int seance_film { get=>_seance_film; set => _seance_film=value; } 
public int place { get=>_place; set => _place=value; } 

}
}
