using System;
using DIO.ProjectOne.Interface;
using System.Collections.Generic;

namespace DIO.ProjectOne{

    public class SeriesRepositorio : IRepositorio<Serie>
    {
        
        
        //Inicialização da lista repositorio.
        private List<Serie> SerieList = new List<Serie>();

        public List<Serie> Lista()
        {
            return SerieList;
        }
        
        public Serie ReturnId(int id)
        {
            return SerieList[id];
        }
        
        public void Insert(Serie objeto)
        {
            SerieList.Add(objeto);
        }
        
        public void Delete(int id)
        {
            SerieList[id].Deletar();
        }
        
        
        public void Update(int id, Serie objeto)
        {
            SerieList[id] = objeto;
        }
        
        public int NextId()
        {
            return SerieList.Count;
        }
    }
}