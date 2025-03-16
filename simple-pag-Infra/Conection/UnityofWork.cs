using Microsoft.EntityFrameworkCore.Storage;
using simple_pag_Domain.Interface;
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

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
