using System;
using System.Diagnostics;
using System.IO;

namespace IniciaSAT
{
    class Program
    {
        private static string tempFile;
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Serviço de SAT compartilhado, por favor aguarde...");
            CreateBat();
            ExecuteBat();
            Console.WriteLine("FIM.");

        }

        private static void CreateBat()
        {
            try
            {
                tempFile = Path.GetTempPath() + "iniciaSAT.bat";
                using(var bat = new StreamWriter(tempFile))
                {
                    bat.WriteLine("net start SrvSatCompartilhado");
                    bat.WriteLine("pause");
                    bat.Close();
                }
                Console.WriteLine("Arquivo criado.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.InnerException);
                throw ex;
            }
        }
        private static void ExecuteBat()
        {
            try
            {
                var p = new Process();
                p.StartInfo.FileName = tempFile;
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                p.WaitForExit();
                Console.WriteLine("Serviço iniciado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.InnerException);
                throw ex;
            }
        }
    }
}
