using System.Collections.Generic;

namespace EFCoreDatabase 
{
    public interface IEFCoreDatabaseContext 
    {
        int AddData (Note note);
        List<Note> GetData ();
        List<Note> GetDataById (string id);
        List<Note> GetDataByType(string id,string type);
    }
}