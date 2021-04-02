using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osumen_TheVirtualFriend
{
    class TaskData
    {
        private string name, date, time, priority;
        public void setName(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public void setDate(string date)
        {
            this.date = date;
        }
        public string getDate()
        {
            return date;
        }
        public void setTime(string time)
        {
            this.time = time;
        }
        public string getTime()
        {
            return time;
        }
        public void setPriority(string priority)
        {
            this.priority = priority;
        }
        public string getPriority()
        {
            return priority;
        }
    }
}
