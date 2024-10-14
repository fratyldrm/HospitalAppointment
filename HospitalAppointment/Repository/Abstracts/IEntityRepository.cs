using HospitalAppointment.Models;

namespace HospitalAppointment.Repository.Abstracts;

public interface IEntityRepository<TEntity> where TEntity : Entity, new()
{
    TEntity? GetById(int id);
    List<TEntity> GetAll();
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(int id);
}
