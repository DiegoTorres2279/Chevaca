using Api.Data;

namespace Board.Data
{
    public class DbInitializer
    {
        public static void Initialize(ChapiDB_Context context)
        {
            bool init = context.Database.EnsureCreated();

            if (init)
            {

            }
        }
    }
}