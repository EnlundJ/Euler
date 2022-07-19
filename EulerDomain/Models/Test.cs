﻿using System.Linq;
using System.Threading.Tasks;
using EulerDb;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DbE = EulerDb.Entities;

namespace EulerDomain.Models
{
    public class Test : DbE.Test
    {
        private readonly EulerDbContextFactory _dbFactory;

        public Test(DbE.Test test, EulerDbContextFactory dbFactory) : base(test.Id, test.ProblemId, test.IsProblem, test.Parameters, test.Answer)
        {
            _dbFactory = dbFactory;
        }

        public T GetParameters<T>() where T : IProblemParameters
        {
            using (var db = _dbFactory.CreateDbContext())
                return JsonConvert.DeserializeObject<T>(db.Tests.First(t => t.Id == Id).Parameters);
        }

        public void SetParameters<T>(T parameters) where T : IProblemParameters
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                db.Tests.First(t => t.Id == Id).Parameters = JsonConvert.SerializeObject(parameters);
                db.SaveChanges();
            }
        }

        public async Task SetParametersAsync<T>(T parameters) where T : IProblemParameters
        {
            using (var db = _dbFactory.CreateDbContext())
            {
                (await db.Tests.FirstAsync(t => t.Id == Id)).Parameters = JsonConvert.SerializeObject(parameters);
                await db.SaveChangesAsync();
            }
        }
    }
}