using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBaseStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            /** 
             Ado.Net Insert, Update and delete functions
             */
            ADO ado = new ADO();

            ado.createDB(); //Create the database. this is to be run only once
            ado.createTable(); //Create table. this is to be run only once
            ado.insertData(); 
            ado.updateTable();
           ado.deleteFromTable();
            Console.WriteLine("results are in, press any key to continue");
            Console.ReadLine();

            /** 
             Entity framework Insert, Update and delete functions
             */
            EntityFramework EF = new EntityFramework();

           EF.insertData();
            EF.updateData();
           EF.deleteData();
            Console.WriteLine("results are in, press any key to continue");
            Console.ReadLine();

            /** 
             MongoDB Insert, Update and delete functions
             */
            MongoDB mdb = new MongoDB();
            mdb.insertData();
            mdb.updateData();
            mdb.deleteData();
            Console.WriteLine("results are in, press any key to exit");
            Console.ReadLine();


        }
    }
}
