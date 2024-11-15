using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMP_2_2_
{
    internal class Generation_table
    {
        List<Group> groups;
        List<Lectoriy> lectoriys;
        List<Terminalclass> terminalclasses;

        public Generation_table(List<Group> groups, List<Lectoriy> lectoriys, List<Terminalclass> terminalclasses)
        {
            
            this.groups = groups;
            this.lectoriys = lectoriys;
            this.terminalclasses = terminalclasses;
        }
        public DataTable GenerationTable()
        {
            DataTable schedule = new DataTable("schedule");
            schedule.Columns.Add("          ", typeof(string));
            schedule.Columns.Add("           ", typeof(string));
            for (int e1 = 0; e1 < lectoriys.Count; e1++)
            {
                schedule.Columns.Add("Лекторий - " + (e1 + 1).ToString(), typeof(string));
            }
            for (int e2 = 0; e2 < terminalclasses.Count; e2++)
            {
                schedule.Columns.Add("Терминал класс - " + (e2 + 1).ToString(), typeof(string));
            }
            schedule.Columns.Add("Военная кафедра", typeof(string));
            DataRow dtr = schedule.NewRow();
            for (int j = 0; j < Program.day_week; j++)
            {
                for (int k = 0; k < Program.day_subject; k++)
                {
                    dtr = schedule.NewRow();
                    for (int e = 0; e < groups.Count; e++)
                    {
                        dtr[0] = days_week(j);
                        dtr[1] = number_sabject(k);
                        for (int e1 = 0; e1 < lectoriys.Count; e1++)
                        {
                            if (groups[e].schedule[j][k].Item2 == "Лекторий - " + (e1 + 1).ToString())
                            {
                                dtr[e1 + 2] = groups[e].schedule[j][k].Item1.name.ToString() + " - " + groups[e].schedule[j][k].Item1.type.ToString() + " (Группа-" + (e + 1).ToString() + ")";
                            }
                        }
                        for (int e2 = 0; e2 < terminalclasses.Count; e2++)
                        {
                            if (groups[e].schedule[j][k].Item2 == "Терминал Класс - " + (e2 + 1).ToString())
                            {
                                dtr[e2 + 2 + lectoriys.Count] = groups[e].schedule[j][k].Item1.name.ToString() + " - " + groups[e].schedule[j][k].Item1.type.ToString() + " (Группа-" + (e + 1).ToString() + ")";
                            }
                        }
                        if (groups[e].schedule[j][k].Item2 == "Военная кафедра")
                        {
                            dtr[terminalclasses.Count + 2 + lectoriys.Count] = groups[e].schedule[j][k].Item1.name.ToString() + " (Группа-" + (e + 1).ToString() + ")";
                        }
                    }
                    schedule.Rows.Add(dtr);

                }
            }
            return schedule;
        }
        public string days_week(int day)
        {
            if (day == 0) return "Понедельник";
            else if (day == 1) return "Вторник";
            else if (day == 2) return "Среда";
            else if (day == 3) return "Четверг";
            else if (day == 4) return "Пятница";
            else if (day == 5) return "Суббота";
            return "Я ДЕБИЛ!!!!";

        }
        public string number_sabject(int time)
        {
            if (time == 0) return "1-ая пара";
            else if (time == 1) return "2-ая пара";
            else if (time == 2) return "3-ая пара";
            else if (time == 3) return "4-ая пара";
            else if (time == 4) return "5-ая пара";
            else if (time == 5) return "6-ая пара";
            return "Я ДЕБИЛ!!!!";

        }
    }
}
