/*
 * Created by SharpDevelop.
 * User:
 * Date: 12/11/2014
 * Time: 04:43 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Practica5
{
	class Program
	{
		public static void Main(string[] args)
		{			
			BaseDeDatos alumnos = new BaseDeDatos();
			String opcion = "";
			int registrosIngresados = 0;
			
			do{
				Console.WriteLine("ELIJA UNA OPCIÓN DEL MENU:");
				Console.WriteLine("1.Agregar registro en la BD.");
				Console.WriteLine("2.Consultar todos los registros.");
				Console.WriteLine("3.Salir.");
				Console.WriteLine();
				Console.WriteLine("INGRESE EL NUMERO DE OPCIÓN");
				int opcionMenu = Int32.Parse( Console.ReadLine() );
				switch(opcionMenu)
				{
					case 1:
						int codigo = 0;
						do{
							try{
								Console.WriteLine("Ingrese el CÓDIGO del Alumno:");
								codigo = Int32.Parse( Console.ReadLine() );
							}catch (Exception e){
								Console.WriteLine("*SE PEDÍA UN VALOR NUMÉRICO.");
								Console.WriteLine(e.Message);
							}
						}while(codigo == 0);
						
						Console.WriteLine("Ingrese el NOMBRE del Alumno:");
						String nombre = Console.ReadLine();
						int telefono = 0;
						do{
							try{
								Console.WriteLine("Ingrese el TELÉFONO del Alumno:");
								telefono = Int32.Parse( Console.ReadLine() );
							}catch (Exception e){
								Console.WriteLine("*SE PEDÍA UN VALOR NUMÉRICO.");
								Console.WriteLine(e.Message);
							}
						}while(telefono == 0);
						Console.WriteLine("Ingrese el E-MAIL del Alumno:");
						String email = Console.ReadLine();
						alumnos.insertarNuevoRegistroCompleto(codigo,nombre,telefono,email);
						codigo = telefono = 0;
						registrosIngresados++;
						break;
					case 2:
						Console.WriteLine("**********************************");
						bool bdVacia = alumnos.mostrarTodos();
						if(bdVacia || registrosIngresados == 0)
							Console.WriteLine("VACÍO" + "\r\n" +
							                 "**********************************");
						break;
					case 3:
						opcion = "salir";
						Console.WriteLine("¡Adiós!");
						break;
						default:Console.WriteLine("** ESA OPCION NO ESTA EN EL MENU **");
						break;
				}
				Console.WriteLine();
			}while(opcion != "salir");
			Console.ReadKey(true);
		}
	}
}