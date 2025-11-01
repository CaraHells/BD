using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.models
{
public class seance
{
private int _seance_id;
private TimeSpan _seance_start;
private TimeSpan _seance_end;
private int _seance_type;


public seance()
{}
public seance (int seance_id, TimeSpan seance_start, TimeSpan seance_end,int seance_type){ 
 this._seance_id=seance_id;
this._seance_start=seance_start;
this._seance_end=seance_end;
this._seance_type=seance_type;
 }
public int seance_id { get=>_seance_id; set => _seance_id=value; } 
public TimeSpan seance_start { get=>_seance_start; set => _seance_start=value; } 
public TimeSpan seance_end { get=>_seance_end; set => _seance_end=value; } 
public int seance_type { get=>_seance_type; set => _seance_type=value; } 

}
}
