using Infrastructure.Repository.Interfaces;
using Infrastructure.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Console
{
    public static class MenusController
    {
        public static void Init()
        {
            MenuFormat();
        }

        public static void MenuFormat()
        {
            FormatChoose();
            int UserChoiceFormat = Convert.ToInt32(System.Console.ReadLine());
            /*FileFactory fileFactory = new FileFactory();
            fileFactory.CreateFileManager(UserChoiceFormat);*/
            switch (UserChoiceFormat)
            {
                case 1:
                    CrudTxt();
                    break;

                case 2:
                    CrudJson();
                    break;

                case 3:
                    CrudXml();
                    break;

                default:
                    System.Console.WriteLine(Console_Resources.InvalidOption);
                    break;
            }
        }


        private static void FormatChoose()
        {
            System.Console.WriteLine(Console_Resources.Enter);
            System.Console.WriteLine(Console_Resources.FormatFile);
            System.Console.WriteLine(Console_Resources.Enter);
            System.Console.WriteLine(Console_Resources.TxtFromat);
            System.Console.WriteLine(Console_Resources.JsonFormat);
            System.Console.WriteLine(Console_Resources.XmlFormat);
            System.Console.WriteLine(Console_Resources.Enter);
        }



        private static void CrudXml()
        {
            IRepository repository = new RepositoryXml();
            MenuCrud(repository);
        }

        private static void CrudJson()
        {
            IRepository repository = new RepositoryJson();
            MenuCrud(repository);
        }

        private static void CrudTxt()
        {
            IRepository repository = new RepositoryTxt();
            MenuCrud(repository);
        }

        public static void MenuCrud(IRepository repository)
        {

            CrudChoose();
            int UserChoice = Convert.ToInt32(System.Console.ReadLine());
            FilesCrud FilesCrud = new FilesCrud();
            switch (UserChoice)
            {
                case 1:
                    FilesCrud.AddStudent(repository);
                    break;

                case 2:
                    FilesCrud.GetAllStudents(repository);
                    break;

                case 3:
                    FilesCrud.GetStudentById(repository);
                    break;

                case 4:
                    FilesCrud.UpdateStudent(repository);
                    break;

                case 5:
                    FilesCrud.DeleteStudent(repository);
                    break;

                case 6:
                    MenuFormat();
                    break;

                case 7:
                    Environment.Exit(1);
                    break;

                default:
                    System.Console.WriteLine(Console_Resources.InvalidOption);
                    break;
            }
        }

        private static void CrudChoose()
        {
            System.Console.WriteLine(Console_Resources.Enter);
            System.Console.WriteLine(Console_Resources.OptionChoose);
            System.Console.WriteLine(Console_Resources.Enter);

            System.Console.WriteLine(Console_Resources.AddStudent);
            System.Console.WriteLine(Console_Resources.GetAllStudents);
            System.Console.WriteLine(Console_Resources.GetStudentById);
            System.Console.WriteLine(Console_Resources.UpdateStudent);
            System.Console.WriteLine(Console_Resources.DeleteStudent);
            System.Console.WriteLine(Console_Resources.ReturnToFormatMenu);
            System.Console.WriteLine(Console_Resources.Exit);
        }
    }
}
