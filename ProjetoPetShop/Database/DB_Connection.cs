using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace Database
{
    class DB_Conexao
    {
        private SqlConnection conn = new SqlConnection
        (@"Server=(local);Database= PETSHOP;Integrated Security=true");

     
     public SqlConnection OpenConnection()
     {
          if(conn.State == ConnectionState.Closed)
            
           conn.Open(); 
           return conn;
           
           
     }

     public SqlConnection ClosedConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return conn;
        }


    }  
}
