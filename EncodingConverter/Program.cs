using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EncodingConverter
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Open streamreader");
				StreamReader sr = new StreamReader(@"C:\boot.ini");
				Console.WriteLine("Open streamwriter");
				StreamWriter sw = new StreamWriter("boot-utf7.txt", false, Encoding.UTF7);
				sw.WriteLine(sr.ReadToEnd());
				sw.Close();
				sr.Close();
				Console.WriteLine("Streams are closed");
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("The file is not found");
			}
			finally
			{
				Console.WriteLine("Press enter to exit...");
				Console.ReadLine();
			}
		}
	}
}
