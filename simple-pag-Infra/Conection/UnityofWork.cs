using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using simple_pag_Domain.Shared.Interface;
using System;



namespace simple_pag_Infra.Conection
    {
        public class UnityOffWork : IUnityOffWork
        {
            private readonly Context _context;
            private IDbContextTransaction _transaction;

            public UnityOffWork(Context context, IDbContextTransaction transaction)
            {
                _context = context;
                _transaction = transaction;
            }

            public bool TransactionActive => _transaction != null && _transaction.GetDbTransaction().Connection != null;

            public void BeginTransaction()
        {
            if (TransactionActive)
            {
                //throw new InvalidOperationException("A transaction is already active.");
                return;
            }

            if (_context.Database.GetDbConnection().State != System.Data.ConnectionState.Open)
            {
                _context.Database.GetDbConnection().Open();
            }

            _transaction = _context.Database.BeginTransaction();
        }

            public void CommitTransaction()
            {
                _transaction?.Commit();
                _transaction = null;
            }

            public void Rollback()
            {
                _transaction?.Rollback();
                _transaction = null;
            }
        }
    }


