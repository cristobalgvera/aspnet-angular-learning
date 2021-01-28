﻿using System;
using System.Collections.Generic;
using Dapper;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface ISpCall : IDisposable
    {
        T Single<T>(string procedureName, DynamicParameters dynamicParameters = null);

        void Execute(string procedureName, DynamicParameters dynamicParameters = null);

        T OneRecord<T>(string procedureName, DynamicParameters dynamicParameters = null);

        IEnumerable<T> List<T>(string procedureName, DynamicParameters dynamicParameters = null);

        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(
            string procedureName,
            DynamicParameters dynamicParameters = null
        );
    }
}