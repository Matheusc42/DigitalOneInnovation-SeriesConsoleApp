using System.Collections.Generic;

namespace DIO.ProjectOne.Interface {
    

    public interface IRepositorio<T>{
    List<T> Lista();
    T ReturnId(int id);
    void Insert(T objeto);
    void Delete(int id);
    void Update(int id, T objeto);
    int NextId();
    
    }
    
}