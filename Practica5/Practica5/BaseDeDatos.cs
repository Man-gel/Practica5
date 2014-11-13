/*
 * Created by SharpDevelop.
 * User: YO WILLY
 * Date: 12/11/2014
 * Time: 05:08 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using MySql.Data.MySqlClient;

namespace Practica5
{
	/// <summary>
	/// Description of BaseDeDatos.
	/// </summary>
	public class BaseDeDatos : MySQL
	{
		public BaseDeDatos()
		{
		}
		
		public bool mostrarTodos(){
			this.abrirConexion();
			bool tablaVacia = false;
			
			try{
				MySqlCommand myCommand = new MySqlCommand(this.querySelect(),
				                                          conexion);
				MySqlDataReader myReader = myCommand.ExecuteReader();
				while ( myReader.Read() ){
					string codigo = myReader["codigo"].ToString();
					string nombre = myReader["nombre"].ToString();
					string telefono = myReader["telefono"].ToString();
					string email = myReader["email"].ToString();
					if(codigo.Length == 0 && nombre.Length == 0 && telefono.Length == 0 && email.Length == 0)
						tablaVacia = true;
					Console.WriteLine(" Código: " + codigo + "\r\n" +
					                  " Nombre: " + nombre + "\r\n" +
					                  " Telefono: " + telefono +"\r\n" +
					                  " e-mail: " + email + "\r\n" +
					                  "**********************************");
				}
					myReader.Close();
					myReader = null;
					myCommand.Dispose();
					myCommand = null;
				
			}catch (Exception e){
				Console.WriteLine(e.Message);
			}finally{
				
				this.cerrarConexion();
			}
			return tablaVacia;
		}

		public void insertarNuevoRegistroCompleto(int codigo, string nombre,int telefono, string email){
			this.abrirConexion();
			try{
				string sql = "INSERT INTO `datosalumnos` (`codigo`, `nombre` ,`telefono`,`email`) VALUES ('" + codigo + "', '" + nombre + "','"+telefono+"','"+email+"')";
				int camposAfectados = this.ejecutarComando(sql);
				Console.WriteLine("*REGISTRO INGRESADO");
			}catch (Exception e){
				Console.WriteLine(e.Message);
			}finally{
				this.cerrarConexion();
			}
		}
	
		private int ejecutarComando(string sql){
			MySqlCommand myCommand = new MySqlCommand(sql,this.conexion);
			int afectadas = myCommand.ExecuteNonQuery();
			myCommand.Dispose();
			myCommand = null;
			return afectadas;
		}

		private string querySelect(){
			return "SELECT * " +
				"FROM datosalumnos";
		}
	}
}
