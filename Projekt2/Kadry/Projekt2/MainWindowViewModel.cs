using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace Projekt2
{
    internal class MainWindowViewModel : IDataErrorInfo
    {
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }
        
        public string this[string name]
        {
            get
            {
                string result = null;

                if (name == "Age")
                {
                    if (this.age < 18 || this.age > 65)
                    {
                        result = "Pracownik nie pełnoletni lub emeryt";
                    }
                }
                return result;
            }
        }
    }




    }
