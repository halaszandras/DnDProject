using System.Collections.ObjectModel;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxStarter.Core.Models;

namespace MvxStarter.Core.ViewModels
{
    public class ShellViewModel : MvxViewModel
    {
        public ShellViewModel()
        {
            AddCharacterCommand = new MvxCommand(AddCharacter);
        }

        public IMvxCommand AddCharacterCommand { get; set; }

        public void AddCharacter()
        {
            CharacterGeneratorModel characterGenerator = new CharacterGeneratorModel
            {
                FirstName = FirstName,
                LastName = LastName
            };

            FirstName = string.Empty;
            LastName = string.Empty;

            CharacterGenerators.Add(characterGenerator);
        }

        public bool CanAddCharacter => FirstName?.Length > 0 && LastName?.Length > 0;

        private ObservableCollection<CharacterGeneratorModel> _characterGenerators = new ObservableCollection<CharacterGeneratorModel>();

		public ObservableCollection<CharacterGeneratorModel> CharacterGenerators
		{
			get { return _characterGenerators; }
            set { SetProperty(ref _characterGenerators, value); }
        }

		private string _firstName;

		public string FirstName
		{
			get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value);
                RaisePropertyChanged(() => FullName);
                RaisePropertyChanged(() => CanAddCharacter);
            }
		}

        private string _lastName;

		public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
                RaisePropertyChanged(() => FullName);
                RaisePropertyChanged(() => CanAddCharacter);
            }
        }

        public string FullName => $"{FirstName} {LastName}";
    }
}
