using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataCashFlow.Models
{
    public class BaseModel
    {
        public BaseModel(string tableName, string primaryKeyField)
        {
            PrimaryKey = primaryKeyField;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            var value = this.GetType().GetProperty(eventArgs.PropertyName).GetValue(this);
            if (value != null && !value.GetType().FullName.Contains("System.Collections"))
            {
                var primaryKey = PrimaryKey == eventArgs.PropertyName;

                RaisePropertyChanged(value.ToString());
            }
        }

        [NotMapped]
        public string PrimaryKey { get; set; }

        public void RaisePropertyChanged(string newValue, bool primaryKey = false, [CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
