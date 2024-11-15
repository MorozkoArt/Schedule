using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Spire.Xls;
using Spire.Xls.AI;
using Spire.Xls.Collections;



namespace HMP_2_2_
{
    internal class Program
    {
        internal const int day_week = 6;
        internal const int day_subject = 6;
        
        public static List<Lectoriy> Generation_Lectories(int count_lect)
        {
            List<Lectoriy> lectoriys = new List<Lectoriy>();
            for (int i = 0; i < count_lect; i++)
            {                
                Lectoriy lectoriy = new Lectoriy(i);
                lectoriys.Add(lectoriy);
            }
            return lectoriys;
        }
        public static List<Terminalclass> Generation_TerminalClasses(int count_terminal)
        {
            List<Terminalclass> terminalclasses = new List<Terminalclass>();
            for (int i = 0; i < count_terminal; i++)
            {
                Terminalclass terminalclass = new Terminalclass(i);
                terminalclasses.Add(terminalclass);
            }
            return terminalclasses;
        }
        public static List<Subject> Generation_Subjects()
        {
            List<Subject> subjects = new List<Subject>();
            subjects.Add(new Subject("Математический анализ", "Лекция"));
            subjects.Add(new Subject("Математический анализ", "Практика"));
            subjects.Add(new Subject("ЭГА", "Лекция"));
            subjects.Add(new Subject("ЭГА", "Практика"));
            subjects.Add(new Subject("Физика", "Лекция"));
            subjects.Add(new Subject("Физика", "Практика"));
            subjects.Add(new Subject("КСЕ", "Лекция"));
            subjects.Add(new Subject("КСЕ", "Практика"));
            subjects.Add(new Subject("C#", "Лекция"));
            subjects.Add(new Subject("C#", "Практика"));
            subjects.Add(new Subject("Теория вычислимости", "Лекция"));
            subjects.Add(new Subject("Методы оптимизации", "Лекция"));
            subjects.Add(new Subject("Теория вероятностей", "Лекция"));
            subjects.Add(new Subject("Дифференциальные уравнения", "Лекция"));
            subjects.Add(new Subject("Алгебра и геометрия", "Лекция"));
            return subjects;
        }
        public static List<Group> Generation_Groups(List<Subject> subjects, int count_sub_group_day, int count_group)
        {
            List<Group> groups = new List<Group>();
            for (int i = 0; i < count_group; i++)
            {
                Group group = new Group(i, subjects, (i*2) % 6, count_sub_group_day);
                groups.Add(group);
            }
            return groups;
        }
        
        
        static void Main(string[] args)
        {
            int count_group,  count_sub_group_day, count_lect, count_terminal;
            count_group = 3;        
            count_sub_group_day = 4;
            count_lect = 2;
            count_terminal = 1;
            
            //создание списка лекториев
            List<Lectoriy> lectoriys = Generation_Lectories(count_lect);
           
            //Создание списка терминалклассов
            List<Terminalclass> terminalclasses = Generation_TerminalClasses(count_terminal);
            
            //Создание списка предметов
            List<Subject> subjects = Generation_Subjects();
            
            //Создание списка групп
            List<Group> groups = Generation_Groups(subjects, count_sub_group_day, count_group);
            
            //Генерация рассписания
            Schedule_generator schedule_Generator = new Schedule_generator(lectoriys, terminalclasses, groups, count_sub_group_day);
            schedule_Generator.Generation();


            // Создание таблицы и перенос ее в excel
            Generation_table generator = new Generation_table(groups, lectoriys, terminalclasses);
            DataTable schedule = generator.GenerationTable();

            string path = @"C:\Users\Артём Морозов\source\repos\HMP_2(2)\DataTableToExcel.xlsx";
            Excel excelTable = new Excel(schedule, path);
            excelTable.generation_excelTable();
        }
    
    }
}
