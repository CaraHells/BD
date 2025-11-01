using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.models
{
public class place
{
private int _place_id;
private int _place_row;
private int _place_col;
public place()
{}
public place (int place_id,int place_row,int place_col){ 
 this._place_id=place_id;
this._place_row=place_row;
this._place_col=place_col;
 }
public int place_id { get=>_place_id; set => _place_id=value; } 
public int place_row { get=>_place_row; set => _place_row=value; } 
public int place_col { get=>_place_col; set => _place_col=value; } 

}
}
