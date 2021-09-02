using System;

namespace DIO.ProjectOne
{
    class Program
    {
        static SeriesRepositorio Repository = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string Input = UserInput();

            //While Statement: keep the program working while user input is equal an option of "UserInput()".
            while(Input.ToUpper() != "X"){
                
                //Switch: validate the user input.
                switch (Input){
                    
                    //Calls the Method ListSerie()
                    case "1":
                        ListSerie();
                    break;
                    
                    //Calls the Method InsertNewSerie()
                    case "2":
                        InsertNewSerie();
                    break;
                    
                    //Calls the ethod UpdateSerie()
                    case "3":
                        UpdateSerie();
                    break;
                    
                    //Calls the Method DeleteSerie()
                    case "4":
                        DeleteSerie();
                    break;
                    
                    //Calls the Method ViewSerie()
                    case "5":
                        ViewSerie();
                    break;
                    
                    //Calls the Method Console.Clear()
                    case "C":
                        Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Input = UserInput();
            }
            Console.WriteLine("Thanks to use our services!");
        }

        //User Input Method: catch the users input to continue the program.
        private static string UserInput(){
            
            Console.WriteLine("==============================");
            Console.WriteLine("== Series System Management ==");
            Console.WriteLine("== Please, choice an option:==");
            Console.WriteLine("== ------------------------ ==");
            Console.WriteLine("== 1- List Series           ==");
            Console.WriteLine("== 2- Insert New Serie      ==");
            Console.WriteLine("== 3- Update Serie          ==");
            Console.WriteLine("== 4- Delete Serie          ==");
            Console.WriteLine("== 5- View Series           ==");
            Console.WriteLine("== C- Clear Console         ==");
            Console.WriteLine("== X- Exit                  ==");
            Console.WriteLine("==============================");
            Console.WriteLine();

            string UserInput = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return UserInput;
        }

        //ListSerie() Method: returns to the user a list of series registred in the Serie Repository.
        private static void ListSerie() {
            Console.WriteLine("==================");
            Console.WriteLine("== List Series  ==");
            Console.WriteLine("==================");

            var List = Repository.Lista();

            //If Statement: Check if the count element of the list is equals zero.
            if ( List.Count == 0){
                Console.WriteLine("No serie were found here! Try register a new serie before accesing this option");
            } 

            //ForEach loop: For Each Serie object found in List<Serie> returns the Id and Series title to the user
            foreach(var serie in List) {
                var deleted = serie.ReturnDeleted();
                if(!deleted){
                    Console.WriteLine("#ID {0} - {1}", serie.returnId(), serie.returnTitle());
                }
            }
        }
        
        //InsertNewSerie() Method: Gives to the user a form to fill with all propertys of Serie Object and add this new object to the List<Serie>
        private static void InsertNewSerie() {
            Console.WriteLine("=======================");
            Console.WriteLine("== Insert New Serie  ==");
            Console.WriteLine("=======================");

            //ForEach Loop: For Each int value in Enum Genre returns the enum value.
            foreach(int i in Enum.GetValues(typeof(Genre))){
                Console.WriteLine("{0} . {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.WriteLine("Insert the genre between the options upside: ");
            int GenreInput = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Insert the series title: ");
            string TitleInput = Console.ReadLine();

            Console.WriteLine("Insert the series release year");
            int YearInput = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Give us a little description of Serie: ");
            string DescInput = Console.ReadLine();

            Serie NewSerie = new Serie(id: Repository.NextId(),
                                       genre: (Genre)GenreInput,
                                       title: TitleInput,
                                       year: YearInput,
                                       description: DescInput);

            Repository.Insert(NewSerie);

        }

        //UpdateSerie() Method: Receive an ID that was input by user, and allows an update on series based on ID
        private static void UpdateSerie() {
            Console.WriteLine("===================");
            Console.WriteLine("== Update Serie  ==");
            Console.WriteLine("===================");
            
            Console.WriteLine("Type the Series ID:");
            int IdInput = Int32.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genre))){
                Console.WriteLine("{0} . {1}", i, Enum.GetName(typeof(Genre), i));
            }

            Console.WriteLine("Insert the genre between the options upside: ");
            int GenreInput = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Insert the series title: ");
            string TitleInput = Console.ReadLine();

            Console.WriteLine("Insert the series release year");
            int YearInput = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Give us a little description of Serie: ");
            string DescInput = Console.ReadLine();

            Serie NewSerie = new Serie(id: IdInput,
                                       genre: (Genre)GenreInput,
                                       title: TitleInput,
                                       year: YearInput,
                                       description: DescInput);

            Repository.Update(IdInput, NewSerie);
        }

        //DeleteSerie() Method: Turn True the "Deleted" property of Serie Object that have the Id informed by user.
        private static void DeleteSerie() {
            Console.WriteLine("===================");
            Console.WriteLine("== Delete Series ==");
            Console.WriteLine("===================");

            Console.WriteLine("Type the Series ID:");
            int IdInput = Int32.Parse(Console.ReadLine());

            Repository.Delete(IdInput);
        }

        //ViewSerie() Method:
        private static void ViewSerie(){
            Console.WriteLine("=================");
            Console.WriteLine("== View Series ==");
            Console.WriteLine("=================");

            Console.WriteLine("Type the Series ID:");
            int IdInput = Int32.Parse(Console.ReadLine());

            var serie = Repository.ReturnId(IdInput);
            Console.WriteLine(serie);
        }


    }
}
