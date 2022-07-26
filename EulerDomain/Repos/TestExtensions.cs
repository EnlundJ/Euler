﻿using System.Linq;
using System.Threading.Tasks;
using EulerDb;
using EulerDb.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EulerDomain.Repos
{
    public static class TestExtensions
    {
        public static T GetParameters<T>(this Test test) where T : IProblemParameters
        {
            return JsonConvert.DeserializeObject<T>(test.Parameters);

            //using (var db = dbFactory.CreateDbContext())
            //    return JsonConvert.DeserializeObject<T>(db.Tests.First(t => t.Id == test.Id).Parameters);
        }

        public static void SetParameters<T>(this Test test, T parameters, EulerDbContextFactory dbFactory) where T : IProblemParameters
        {
            using (var db = dbFactory.CreateDbContext())
            {
                db.Tests.First(t => t.Id == test.Id).Parameters = JsonConvert.SerializeObject(parameters);
                db.SaveChanges();
            }
        }

        public static async Task SetParametersAsync<T>(this Test test, T parameters, EulerDbContextFactory dbFactory) where T : IProblemParameters
        {
            using (var db = dbFactory.CreateDbContext())
            {
                (await db.Tests.FirstAsync(t => t.Id == test.Id)).Parameters = JsonConvert.SerializeObject(parameters);
                await db.SaveChangesAsync();
            }
        }
    }
}