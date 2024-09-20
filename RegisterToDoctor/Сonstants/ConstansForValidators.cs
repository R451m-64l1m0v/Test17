namespace RegisterToDoctor.Сonstants
{
    public static class ConstansForValidators
    {
        public static DateTime maxAge = new DateTime(1900, 1, 1);
        public static DateTime minAge = DateTime.Today.AddDays(1);
        public static int OmsLength = 16;
        public static int PageSizeLimit = 500;
    }
}
