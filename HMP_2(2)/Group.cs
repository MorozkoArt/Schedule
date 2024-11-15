using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMP_2_2_
{
    internal class Group
    {
        int number;
        public int max_sub_day;
        public int day_var;
        public List<Subject> subjects;
        public Subject var_sabject = new Subject("Военная кафедра", "NULL") ;
        public List<List<Tuple<Subject, string>>> schedule = new List<List<Tuple<Subject, string>>>();
        public Group(int number, List<Subject> subjects, int day_var, int max_sub_day) 
        { 
            this.number = number;
            this.subjects = subjects.ToList();
            this.day_var = day_var;
            this.max_sub_day = max_sub_day;
            for (int j = 0; j < Program.day_week; j++)
            {
                List<Tuple<Subject, string>> list3 = new List<Tuple<Subject, string>>();
                this.schedule.Add(list3);
                for (int k = 0; k < Program.day_subject; k++)
                {
                    this.schedule[j].Add(new Tuple<Subject, string>(null , " "));
                }
            }
        }

    }
}
