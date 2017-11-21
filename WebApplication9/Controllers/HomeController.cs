using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Formatters.Binary;
using WebApplication9.Models;



namespace WebApplication9.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }





        public ActionResult AddRecord(Book book)  //Begin add new people
        {
            if (System.IO.File.Exists(@"C:\Users\1\YandexDisk\WebApplication9\note.dat") && (new FileInfo(@"C:\Users\1\YandexDisk\WebApplication9\note.dat")).Length > 0) //the file checks existence. If "yes", get data in variable "fStream"
            {

                BinaryFormatter formatter = new BinaryFormatter();
                using (var fStream = System.IO.File.Open(@"C:\Users\1\YandexDisk\WebApplication9\note.dat", FileMode.Open)) // open the file

                {
                    List<Book> noteBook = (List<Book>)formatter.Deserialize(fStream); //add data from file in a collection "noteBook"
                    noteBook.Add(book);                                               // add information about new people
                    fStream.Position = 0;                                             // update fStream
                    formatter.Serialize(fStream, noteBook);                           //Serializable fStream
                }




            }


            else
            {                                                                     //Create file and add new record. If it is not find file with data 
                BinaryFormatter formatter = new BinaryFormatter();
                List<Book> noteBook = new List<Book>();                              //Create collection NoteBook  
                noteBook.Add(book);                                                  // Add new element in collection
                using (var fstream = new FileStream(@"C:\Users\1\YandexDisk\WebApplication9\note.dat", FileMode.Create, FileAccess.Write, FileShare.None)) // Create file and serialize
                { formatter.Serialize(fstream, noteBook); }
                
            }


            return View ();
        }

        [HttpPost]
        public ActionResult FindRES (Find find) //Find people
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using ( var fStream = System.IO.File.OpenRead(@"C:\Users\1\YandexDisk\WebApplication9\note.dat")) //Open file for serialize

            {
                List<Book> noteBook = (List<Book>)formatter.Deserialize(fStream); //Create collection NoteBook
                var fbook = from book in noteBook    //search of objects which satisfy to search parameters
                            where book.FirstName == find.FindName || book.LastName == find.FindName || book.Phone == find.FindName
                            select book;

                // Show result in Index.cshtml
                ViewBag.FindResult = fbook;



            }

            return View();
        }


        // to sort by a surname
        public ActionResult Sort ()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fStream = System.IO.File.OpenRead(@"C:\Users\1\YandexDisk\WebApplication9\note.dat")) //Open file for serialize

            {
                List<Book> noteBook = (List<Book>)formatter.Deserialize(fStream); //Create collection NoteBook
                var sbook = from book in noteBook    //search of objects which satisfy to search parameters
                            orderby book.LastName
                            select book;

                // Show result in Sort.cshtml
                ViewBag.FindResult = sbook;
            }
            return View();
        
        }

        //to sort by a day of birthday
        public ActionResult DSort()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fStream = System.IO.File.OpenRead(@"C:\Users\1\YandexDisk\WebApplication9/note.dat")) //Open file for serialize

            {
                List<Book> noteBook = (List<Book>)formatter.Deserialize(fStream); //Create collection NoteBook
                var sbook = from book in noteBook    //search of objects which satisfy to search parameters
                            orderby book.Data
                            select book;
                
                // Show result in Index.cshtml
                ViewBag.FindResult = sbook;
            }
           
            return View();

        }


    }
} 






   