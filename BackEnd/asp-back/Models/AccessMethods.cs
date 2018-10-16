using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabase
{
    public class AccessMethods : IEFCoreDatabaseContext 
    {
        EFCoreDatabaseContext databaseContext=new EFCoreDatabaseContext();
        public int AddData(Note note)
        {
            try
            {
                databaseContext.Notes.Add(note);
                databaseContext.SaveChanges();
                return 1;
            }catch(Exception e)
            {
                string message=e.Message;
                throw new Exception("Could not connect to server");
            }
        }
        public List<Note> GetData()
        {
            try
            {
                var data=databaseContext.Notes.Include(n=>n.checkList).Include(n=>n.label).ToList();
                return data;
            }catch(Exception e)
            {
                string message=e.Message;
                throw new Exception("could not connect to server");
            }
        }
        public List<Note> GetDataById(string title)
        {
            return databaseContext.Notes.Where(t=>t.title==title).Include(n=>n.checkList).Include(n=>n.label).ToList();
        }
        public List<Note> GetDataByType(string id,string type)
        {
            List<Note> notes=new List<Note>();
            try
            {
                switch(type)
                {
                    case "title":   var output=databaseContext.Notes.Where(n=>n.title==type).ToList();
                                    return output;
                    case "label":   var labels=databaseContext.Labels.Where(n=>n.labelname==type).ToList();
                                    foreach (Label label in labels)
                                    {
                                        notes.AddRange(databaseContext.Notes.Where(n=>n.NoteId==label.NoteId).ToList());
                                    }
                                    return notes;
                    default : return notes;
                }
            }catch(Exception e)
            {
                string message=e.Message;
                throw new Exception("could not complte operation");
            }
            
        }
    }
}