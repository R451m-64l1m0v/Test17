using RegisterToDoctor.Models.Doctors.Request;

namespace RegisterToDoctor.Validators
{
    public static class UserEntityValidator
    {
        public static bool CheckFullNames(string firstName, string LastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) ||
                    string.IsNullOrWhiteSpace(LastName)) 
            {
                throw new ArgumentException($"Ошибка: не заполнены поля Фамилии или Имени");
            }
            return true;   
        }        
    }
}
