using System;

namespace DIO.ProjectOne
{
    public class Serie : BaseClass
    {
        //Attributes
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        //Constructor Method.
        public Serie (int id, Genre genre, string title, string description, int year){
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        //ToString Method
        public override string ToString()
        {
            string retorno = "";
            retorno += "Genre: " + this.Genre + Environment.NewLine;
            retorno += "Title: " + this.Title + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Release: " + this.Year + Environment.NewLine;
            retorno += "Deleted(?):" + this.Deleted + Environment.NewLine;
            return retorno;
        }

        //Return Title Method
        public string returnTitle(){
            return this.Title;
        }

        //Return Id Method
        public int returnId(){
            return this.Id;
        }

        //Delete Method.
        public void Deletar() {
            this.Deleted = true;
        }

        //Return Deleted Method
        public bool ReturnDeleted(){
            return this.Deleted;
        }
    }
}
