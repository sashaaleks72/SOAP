using System.Collections.Generic;
using System.Linq;
using WcfTest.Interfaces;
using WcfTest.Models;

namespace WcfTest.Services
{
    public class TeapotService : ITeapotService
    {
        public int AddTeapot(Teapot newTeapot)
        {
            int addedRows = 0;

            using (var dbContext = new AppDbContext())
            {
                dbContext.Teapots.Add(newTeapot);
                addedRows = dbContext.SaveChanges();
            }

            return addedRows;
        }

        public int DeleteTeapotById(int id)
        {
            var teapotToDelete = GetTeapotById(id);
            int deletedRows = 0;

            using (var dbContext = new AppDbContext())
            {
                bool ifExists = dbContext.Teapots.Any(teapot => teapot.Id == teapotToDelete.Id);

                if (ifExists)
                {
                    dbContext.Entry(teapotToDelete).State = System.Data.Entity.EntityState.Deleted;
                    deletedRows = dbContext.SaveChanges();
                }
            }

            return deletedRows;
        }

        public int EditTeapot(Teapot editedTeapot)
        {
            int changedRows = 0;

            using (var dbContext = new AppDbContext())
            {
                bool ifExists = dbContext.Teapots.Any(teapot => teapot.Id == editedTeapot.Id);

                if (ifExists)
                {
                    dbContext.Entry(editedTeapot).State = System.Data.Entity.EntityState.Modified;
                    changedRows = dbContext.SaveChanges();
                }
            }

            return changedRows;
        }

        public Teapot GetTeapotById(int id)
        {
            Teapot recievedTeapot = null;

            using (var dbContext = new AppDbContext())
            {
                recievedTeapot = dbContext.Teapots.FirstOrDefault(t => t.Id == id);
            }

            return recievedTeapot;
        }

        public List<Teapot> GetTeapots()
        {
            List<Teapot> recievedTeapots = null;

            using (var dbContext = new AppDbContext())
            {
                recievedTeapots = dbContext.Teapots.ToList();
            }

            return recievedTeapots;
        }
    }
}
