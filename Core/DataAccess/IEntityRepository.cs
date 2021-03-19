using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //T yerine kısıt vermezsek int bile yazabilirler o yüzden generic constraint(kısıtlama)koyarız.
    //T: class dedik (T referans tip olabilir.) 
    //T: IEntity dedik. Veritabanı nesnemiz olmalı dedik.
    //T: new () dedik ki IEntityin kendisi olmasın. new lenebilir olsun dedik.
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); // Filtre vermezse Tüm listeyi getirir. Verirsede filtreye uyan verileri getirir
        T Get(Expression<Func<T, bool>> filter); //Burda filtre vermek zorunlu
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
