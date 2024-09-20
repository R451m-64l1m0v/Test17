using RegisterToDoctor.Models.Doctors.Request;

namespace RegisterToDoctor.Validators
{
    public static class UserEntityValidator
    {
        public static bool CheckFullNames(string firstName, string LastName, string middleName)
        {
            if (string.IsNullOrWhiteSpace(firstName) 
                || string.IsNullOrWhiteSpace(LastName)) 
            {
                throw new ArgumentException($"Ошибка: поле Фамилии или Имени заполнено некорректно.");
            }

            if (middleName != null && string.IsNullOrWhiteSpace(middleName))
            {
                throw new ArgumentException("Ошибка: поле Отчества заполнено некорректно.");
            }

            return true;   
        }        
    }
}
