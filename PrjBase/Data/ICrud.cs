using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrjBase.Data
{
    public interface ICrud<T, Ts>
    {
        Task<T?> GetByID(int pkID);
        Task<T?> GetByID(int pkID, bool doLoadLists);
        Task<Ts> GetAll();
        Task<T> Insert(T model);
        Task<int> Update(T model);
        Task Delete(int pkID);

        //* Event Definition

        event Action? Inserted;
        event Action? Deleted;
    }
    public interface IPaging<T>
    {
        Task<List<T>> GetAll_Paged_Sorted_andFiltered(
            int pageIndex = 0
            , int pageSize = 20
            , string? sortColumn = null
            , string sortOrder = "ASC"
            , string? filterQuery = null
            );
        //Task<List<T>> GetAll_Paged_Sorted_andFiltered(
        //                                GetDataRequest<T> getDataRequest);
    }
    public interface ICount<T>
    {
        Task<int> GetAllRecordCount();
    }
    public interface ICrud<T>
    {
        Task<T?> GetByID(int pkID);
        Task<T?> GetByID(int pkID, bool doLoadLists);
        Task<List<T>> GetAll();
        Task<T> Insert(T model);
        Task<int> Update(T model);
        Task<bool> Delete(int pkID);

        //* Event Definition

        event Action? Inserted;
        event Action? Deleted;
    }

    public interface ISearch<T,Ts>
    {
        //Task<Ts> Search(Func<string> getSql);     //* Do not use this. Code Generation should add it
        Task<Ts> Search(string? dataToSearch);
        //Task<Ts> Search(Func<T, bool> wherePredicate);
        //Task<Ts> Search(Expression<Func<T, bool>> wherePredicate);
    }
    public interface ISearch<T>
    {
        //Task<Ts> Search(Func<string> getSql);     //* Do not use this. Code Generation should add it
        Task<List<T>> Search(string dataToSearch);      //* Parameter should not be string? because there is no use to search for empty
        //Task<Ts> Search(Func<T, bool> wherePredicate);
        Task<List<T>> Search(Expression<Func<T, bool>> wherePredicate); //* EF only. See if it can be implemented as an extension method
    }
    //public interface IEFSearch<T>
    //{
    //    Task<List<T>> Search(Expression<Func<T, bool>> wherePredicate);
    //}
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetFromView(string viewName);
    }
}
