using System;
using System.IO;
using Windows.Storage;
using PersonMvvmXF.Ioc;
using PersonMvvmXF.UWP.Implementations;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqLiteConnection))]
namespace PersonMvvmXF.UWP.Implementations
{
    public class SqLiteConnection : ISqLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            try
            {
                SQLitePCL.Batteries.Init();
                return new SQLiteConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, "persons.db3"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
