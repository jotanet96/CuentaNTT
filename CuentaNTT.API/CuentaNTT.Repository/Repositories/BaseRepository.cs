using CuentaNTT.Infraestructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using CuentaNTT.Core.Interfaces;
using CuentaNTT.Repository.Data;
using CuentaNTT.Core.Models;
using System.Reflection;
using System;

namespace CuentaNTT.Repository.Repositories {
    public class BaseRepository<T, I> : IBaseRepository<T, I> where T : BaseEntity<I> {

        private readonly CuentaNTTDBContext _db;
        private readonly DbSet<T> _entities;
        public BaseRepository(CuentaNTTDBContext db) {
            _db = db;
            _entities = db.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync() {
            IEnumerable<T>? _lst = await _entities.ToListAsync();

            if (!_lst.Any()) throw new NotFoundException(Constants.MULTIPLENOTFOUND);

            return _lst;
        }
        public async Task<T> GetByIdAsync(I id) {
            T? _entity = await _entities.FindAsync(id);

            if (_entity == null) throw new NotFoundException(Constants.NOTFOUND);

            return _entity;
        }
        public async Task<T> AddAsync(T entity) {
            _entities.Add(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
        public async Task<bool> UpdateAsync(T entity) {
            _entities.Update(entity);
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(I id) {
            T _entity = await GetByIdAsync(id);

            _entities.Remove(_entity);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}