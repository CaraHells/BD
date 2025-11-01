using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.infrastructure
{
    public class DBconn
    {
        //todo: вынести подключения в диалоговое окно с сохранением в реестр/файл
        public const string stringConnection = @"Server=172.21.16.116;Port=5432;Database=user1;UID=prb01;PWD=prb01";
        static NpgsqlConnection _npgsqlConnection;

        public static NpgsqlConnection SqlConnection
        {
            get
            {
                if(_npgsqlConnection == null )
                {
                    _npgsqlConnection = new NpgsqlConnection(stringConnection);
                }
                if (_npgsqlConnection.State != System.Data.ConnectionState.Open)
                {
                    _npgsqlConnection.Open();
                }
                return _npgsqlConnection;
            }
        }
    }
}
