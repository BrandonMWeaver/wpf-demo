using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFDemoUI.Models;
using WPFDemoUI.ViewModels.Commands;
using WPFDemoUI.ViewModels.ViewModelBases;

namespace WPFDemoUI.ViewModels
{
    class PersonViewModel : PersonViewModelBase
    {
        private ObservableCollection<PersonModel> _people;

        public ObservableCollection<PersonModel> People
        {
            get { return this._people; }
            set
            {
                this._people = value;
                this.OnPropertyChanged(nameof(this.People));
            }
        }

        public ClassCommand<string> UpdateCommand { get; set; }

        public PersonViewModel()
        {
            this.People = new ObservableCollection<PersonModel>();
            this.UpdateCommand = new ClassCommand<string>(Update);

            using (StreamReader reader = new StreamReader("../../Storage/Data.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    PersonModel person = new PersonModel
                    {
                        FirstName = data[0],
                        LastName = data[1],
                        PhoneNumber = data[2],
                        EmailAddress = data[3]
                    };

                    this.People.Add(person);
                }
            }
        }

        public void Update(string dataString)
        {
            try
            {
                this.DataString = dataString;

                string[] data = this.DataString.Split(',');

                PersonModel person = new PersonModel
                {
                    FirstName = data[0],
                    LastName = data[1],
                    PhoneNumber = data[2],
                    EmailAddress = data[3]
                };

                File.AppendAllText("../../Storage/Data.txt", $"{person}\n");

                this.People.Add(person);
                this.DataString = string.Empty;
                this.ErrorMessage = string.Empty;
            }
            catch
            {
                this.ErrorMessage = "Invalid entry!";
            }
        }
    }
}
