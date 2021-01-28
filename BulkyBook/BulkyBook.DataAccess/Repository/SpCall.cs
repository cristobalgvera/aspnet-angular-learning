using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.Repository
{
    public class SpCall : ISpCall
    {
        private readonly ApplicationDbContext _dbContext;
        private static string _connectionString = "";

        public SpCall(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _connectionString = dbContext.Database.GetDbConnection().ConnectionString;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Execute(string procedureName, DynamicParameters dynamicParameters = null)
        {
            using var sqLiteConnection = new SQLiteConnection(_connectionString);

            sqLiteConnection.Open();
            sqLiteConnection.Execute(
                procedureName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public T Single<T>(string procedureName, DynamicParameters dynamicParameters = null)
        {
            using var sqLiteConnection = new SQLiteConnection(_connectionString);

            sqLiteConnection.Open();
            
            return (T) Convert.ChangeType(sqLiteConnection.ExecuteScalar<T>(
                procedureName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure
            ), typeof(T));
        }

        public T OneRecord<T>(string procedureName, DynamicParameters dynamicParameters = null)
        {
            using var sqLiteConnection = new SQLiteConnection(_connectionString);

            sqLiteConnection.Open();
            var value = sqLiteConnection.Query<T>(
                procedureName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure
            );

            return (T) Convert.ChangeType(value.FirstOrDefault(), typeof(T));
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters dynamicParameters = null)
        {
            using var sqLiteConnection = new SQLiteConnection(_connectionString);

            sqLiteConnection.Open();
            return sqLiteConnection.Query<T>(
                procedureName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(
            string procedureName,
            DynamicParameters dynamicParameters = null
        )
        {
            using var sqLiteConnection = new SQLiteConnection(_connectionString);

            sqLiteConnection.Open();
            var result = sqLiteConnection.QueryMultiple(
                procedureName,
                dynamicParameters,
                commandType: CommandType.StoredProcedure
            );

            var item1 = result.Read<T1>().ToList();
            var item2 = result.Read<T2>().ToList();

            if (!item1.Any() || !item2.Any())
                return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
        }
    }
}