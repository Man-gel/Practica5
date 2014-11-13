/*
 * Created by SharpDevelop.
 * User: YO WILLY
 * Date: 12/11/2014
 * Time: 05:03 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MySql.Data.MySqlClient;

namespace Practica5
{
	public class MySQL
	{
		protected MySqlConnection conexion;
		public MySQL ()
		{
		}

		protected void abrirConexion(){
			try{
				string connectionString =
					"Server=localhost;" +
					"Database=alumnos;" +
					"User ID=root;" +
					"Password=1234;" +
					"Pooling=false;";
				this.conexion = new MySqlConnection(connectionString);
				this.conexion.Open();
			}catch (Exception e){
				Console.WriteLine(e.Message);
			}
		}

		protected void cerrarConexion(){
			this.conexion.Close();
			this.conexion = null;
		}
	}
}
